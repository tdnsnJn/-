using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2maneger : MonoBehaviour
{
    public GameObject stone;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioSource source;
    public int stage;
    public int ski;
    public bool isflag = true;
    public bool isflag2 = true;
    public float linetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        stone.gameObject.SetActive(false);
        stage = PlayerPrefs.GetInt("Sinkou");
        ski = PlayerPrefs.GetInt("skils");
    }

    // Update is called once per frame
    void Update()
    {
        if (stage >= 2)
        {
            stone.gameObject.SetActive(true);
        }
        if (stage == 1 && ski != 1)
        {
            linetime += Time.deltaTime;
            if (isflag == true)
            {
                source.PlayOneShot(clip);
                isflag = false;
            }
            if (isflag2 == true && linetime >= 8.0f)
            {
                PlayerPrefs.SetInt("skilflag", 1);
                source.PlayOneShot(clip2);
                isflag2 = false;
            }
        }
    }
}
