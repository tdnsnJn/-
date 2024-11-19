using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class First_perspective : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;
    public Transform StartPoint;
    public Transform StartPoint3;
    public GameObject cmr;
    public Image life1;
    public Image life2;
    public Image life3;
    Quaternion cameraRot, charaRot;
    float Xsensityvity = 7f, Ysensityvity = 7f;
    public int Zanki = 3;
    public int save;
    bool cursorLock = true;
    public Shikai_Enemy es;
    //Šp“x‚Ì§ŒÀ
    float minX = -90f, maxX = 90f;
    public int pskil;
    public AudioClip kon;
    public AudioClip kami;
    public AudioSource ko;
    public Manager cry;
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
    // Start is called before the first frame update
    void Start()
    {
        int bsec = PlayerPrefs.GetInt("sec");
        save = PlayerPrefs.GetInt("Sinkou");
        rsec = bsec;
        life1.gameObject.SetActive(false);
        life2.gameObject.SetActive(false);
        life3.gameObject.SetActive(false);
        cameraRot = cmr.transform.localRotation;
        charaRot = transform.localRotation;
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
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isboost == false && brtime >= 7)
            {
                isboost = true;
                brtime = 0;
            }
        }
        if(btime >= 8)
        {
            isboost = false;
        }
        if(isboost == false)
        {
            brtime += Time.deltaTime;
        }
        if (iszanki == false)
        {
            ztime += Time.deltaTime;
        }
        if(ztime >= 1)
        {
            iszanki = true;
            ztime = 0;
        }
        if(Zanki <= 2)
        {
            life3.gameObject.SetActive(false);
        }
        if(Zanki <= 1)
        {
            life2.gameObject.SetActive(false);
        }
        if (Zanki <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }

    private void FixedUpdate()
    {
        if (isPlay == false) return;
        x = 0;
        z = 0;
        if (isboost == true)
        {
            speed = 0.25f;
            btime += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.15f;
        }
        else
        {
            speed = 0.1f;
        }
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        // ˆÚ“®•ûŒü‚Ì’²®
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

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX,minX,maxX);
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(Zanki > 0 && iszanki == true)
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
            if(save == 0)
            {
                PlayerPrefs.SetInt("Sinkou", 1);
            }
            if(sec > rsec)
            {
                PlayerPrefs.SetInt("sec", sec);
            }
            Score_Result();
            SceneManager.LoadScene("Result");
        }
    }

    private void Reset()
    {
        if(MyCrystal > 0 && MyCrystal < 293)
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
