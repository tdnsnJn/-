using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Stage3_perspon : MonoBehaviour
{
    [SerializeField] private Transform self;
    [SerializeField] private Transform enemy;
    [SerializeField] private float sightAngle;
    [SerializeField] private float maxDistance = float.PositiveInfinity;
    float x, z;
    float speed = 0.1f;
    public GameObject cmr;
    Quaternion cameraRot, charaRot;
    float Xsensityvity = 7f, Ysensityvity = 7f;
    public int Zanki = 3;
    bool cursorLock = true;
    public Kanban_shikai kbs;
    //角度の制限
    float minX = -90f, maxX = 90f;
    public int pskil;
    public AudioClip kon;
    public AudioClip kami;
    public AudioSource ko;
    public int MyCrystal = 0;
    public int crymore = 0;
    public int onechan = 0;
    public bool isPlay = false;
    public int sec = 0;
    public int rsec;
    public int dss = 0;
    public float time = 0;
    public float ztime;
    public float btime;
    public float brtime = 7;
    public bool isboost = false;
    public bool iszanki = true;
    public Vector3 moveVector;
    public bool isWallHit = false;
    public bool isLine = true;
    private Transform target;           // 追跡ターゲット
    private Vector3 targetDirection;  // ターゲットの向きベクトル
    private float targetDistance;   // ターゲットの距離
    private float targetAngle;      // ターゲットの角度
    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cmr.transform.localRotation;
        charaRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charaRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cmr.transform.localRotation = cameraRot;
        transform.localRotation = charaRot;
        Ray ray = new Ray(this.transform.position, moveVector.normalized);
        RaycastHit raycastHit;
        Debug.DrawRay(this.transform.position, moveVector.normalized * 1.5f, Color.red);
        this.isWallHit = false;
        if (Physics.Raycast(ray, out raycastHit, 1.5f))
        {
            //Debug.Log("Raycast = Wall-Group[ " + raycastHit.collider.gameObject.transform.parent + "]\nWall[" + raycastHit.collider.gameObject.name + "]");

            if (raycastHit.collider.transform.tag == "Wall" || raycastHit.collider.transform.tag == "Crystal" || raycastHit.collider.transform.tag == "Portal" || raycastHit.collider.transform.tag == "Secret" || raycastHit.collider.transform.tag == "Barrier")
            {   // 壁に当たった
                this.isWallHit = true;
                //Debug.Log("壁");
            }
        }
    }
    private void FixedUpdate()
    {
        x = 0;
        z = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isboost == false)
            {
                speed = 0.2f;
            }
        }
        else
        {
            if (isboost == false)
            {
                speed = 0.1f;
            }
        }
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        if (this.isWallHit)
        {
            x = 0;
            z = 0;
        }

        // 移動方向の調整
        moveVector = cmr.transform.forward * z + cmr.transform.right * x;
        moveVector.y = 0;

        transform.position += moveVector;
    }
    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
    }
    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, minX, maxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
    public bool IsVisible()
    {
        var selfPos = self.position;
        var enemyPos = enemy.position;
        var selfDir = self.forward;

        var enemyDir = enemyPos - selfPos;
        var enemyDistance = enemyDir.magnitude;

        var cosHalf = Mathf.Cos(sightAngle / 2 * Mathf.Deg2Rad);

        var innerProduct = Vector3.Dot(selfDir, enemyDir.normalized);

        return innerProduct > cosHalf && enemyDistance < maxDistance;
    }
    
}
