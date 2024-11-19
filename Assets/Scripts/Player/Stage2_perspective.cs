using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2_perspective : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;
    public Transform StartPoint;
    public Transform StartPoint3;
    public Image boost_i;
    public GameObject cmr;
    public Image life1;
    public Image life2;
    public Image life3;
    Quaternion cameraRot, charaRot;
    float Xsensityvity = 7f, Ysensityvity = 7f;
    public int Zanki = 3;
    bool cursorLock = true;
    public Meid_shikai es;
    //角度の制限
    float minX = -90f, maxX = 90f;
    public int pskil;
    public AudioClip kon;
    public AudioClip kami;
    public AudioClip metan;
    public AudioClip barin;
    public AudioSource ko;
    public Second_manager cry;
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
    
    // Start is called before the first frame update
    void Start()
    {
        int bsec = PlayerPrefs.GetInt("sec2");
        pskil = PlayerPrefs.GetInt("skils");
        rsec = bsec;
        life1.gameObject.SetActive(false);
        life2.gameObject.SetActive(false);
        life3.gameObject.SetActive(false);
        cameraRot = cmr.transform.localRotation;
        charaRot = transform.localRotation;
        boost_i.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay == false) return;
        time += Time.deltaTime;
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charaRot *= Quaternion.Euler(0, xRot, 0);

        cameraRot = ClampRotation(cameraRot);

        cmr.transform.localRotation = cameraRot;
        transform.localRotation = charaRot;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        Ray ray = new Ray(this.transform.position, moveVector.normalized);
        RaycastHit raycastHit;
        Debug.DrawRay(this.transform.position, moveVector.normalized * 1.5f,Color.red);
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
        if(brtime >= 7)
        {   // ブーストリチャージ完了
            boost_i.gameObject.SetActive(true);
        }
        if (iszanki == false)
        {
            ztime += Time.deltaTime;
        }
        if (ztime >= 1)
        {
            iszanki = true;
            ztime = 0;
        }
        if (Zanki <= 2)
        {
            life3.gameObject.SetActive(false);
        }
        if (Zanki <= 1)
        {
            life2.gameObject.SetActive(false);
        }
        if (Zanki <= 0)
        {
            SceneManager.LoadScene("Gameover2");
        }
    }
    private void FixedUpdate()
    {
        if (isPlay == false) return;
        x = 0;
        z = 0;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(isboost == false)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            ko.PlayOneShot(kon);
            cry.HikiCrystal();
            MyCrystal++;
            crymore++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Barrier") && isboost == true)
        {
            ko.PlayOneShot(barin);
                Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Line") && isLine == true)
        {
            ko.PlayOneShot(metan);
            isLine = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Zanki > 0 && iszanki == true)
            {
                Zanki--;
                dss++;
                iszanki = false;
            }
            crymore = 0;
            Reset();
            es.Reset();
        }
        if (other.gameObject.CompareTag("First"))
        {
            cry.StFirst();
            cry.Bgm_start();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Second"))
        {
            cry.StSecond();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Last"))
        {
            cry.StLast();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Secret"))
        {
            sec++;
            other.gameObject.SetActive(false);
            ko.PlayOneShot(kami);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Portal"))
        {
            PlayerPrefs.SetInt("Sinkou", 2);
            if (sec > rsec)
            {
                PlayerPrefs.SetInt("sec2", sec);
            }
            Score_Result();
            SceneManager.LoadScene("Result2");
        }
    }
    private void Reset()
    {
        if (MyCrystal < 155)
        {
            transform.position = StartPoint.position;
        }
        else
        {
            transform.position = StartPoint3.position;
        }
    }
    public void PlayGame()
    {
        isPlay = true;
    }

    public void Score_Result()
    {
        Result_num.Rtime = time;
        Result_num.Rsec = sec;
        Result_num.Rdss = dss;
        Result_num.Rrc = crymore;
    }
}
