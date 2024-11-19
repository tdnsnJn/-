using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class First_player : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;
    public GameObject cmr;
    public Image boost_i;
    public AudioClip barin;
    public AudioSource ko;
    Quaternion cameraRot, charaRot;
    float Xsensityvity = 7f, Ysensityvity = 7f;
    bool cursorLock = true;
    int pskil;
    //角度の制限
    float minX = -90f, maxX = 90f;
    public Vector3 moveVector;
    public bool isWallHit = false;
    public float btime;
    public float brtime = 7;
    public bool isboost = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cmr.transform.localRotation;
        charaRot = transform.localRotation;
        boost_i.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pskil = PlayerPrefs.GetInt("skils");
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
        if(pskil == 0)
        {
            brtime = 0;
        }
        if (Physics.Raycast(ray, out raycastHit, 1.5f))
        {
            //Debug.Log("Raycast = Wall-Group[ " + raycastHit.collider.gameObject.transform.parent + "]\nWall[" + raycastHit.collider.gameObject.name + "]");

            if (raycastHit.collider.transform.tag == "Portal2" || raycastHit.collider.transform.tag == "Gate2" || raycastHit.collider.transform.tag == "Portal" || raycastHit.collider.transform.tag == "Portal1" || raycastHit.collider.transform.tag == "Barrier" || raycastHit.collider.transform.tag == "Portal3"
                 || raycastHit.collider.transform.tag == "Wall")
            {   // 壁に当たった
                this.isWallHit = true;
                //Debug.Log("壁");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            if (isboost == false && brtime >= 7)
            {
                isboost = true;
                brtime = 0;
            }
        }
        if (isboost == true)
        {   // ブースト中
            speed = 0.4f;
            btime += Time.deltaTime;
        }
        if (btime >= 8)
        {   // ブースト終了
            isboost = false;
            btime = 0;
        }
        if (isboost == false)
        {   // ブーストリチャージ
            boost_i.gameObject.SetActive(false);
            brtime += Time.deltaTime;
        }
        if (brtime >= 7)
        {   // ブーストリチャージ完了
            boost_i.gameObject.SetActive(true);
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
        Vector3 moveVector = cmr.transform.forward * z + cmr.transform.right * x;
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
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("Ballrooms");
        }
        if (other.gameObject.CompareTag("Portal1"))
        {
            SceneManager.LoadScene("Gate1");
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.gameObject.CompareTag("Barrier") && isboost == true)
        {
            ko.PlayOneShot(barin);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Portal2"))
        {
            SceneManager.LoadScene("Gate2");
        }
        if (other.gameObject.CompareTag("Gate2"))
        {
            SceneManager.LoadScene("Second_scene");
        }
        if (other.gameObject.CompareTag("Portal3"))
        {
            SceneManager.LoadScene("Comming");
        }

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
}
