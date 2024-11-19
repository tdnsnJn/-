using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_manager : MonoBehaviour
{
    public float onTime;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioSource source;
    public bool flag = true;
    public bool flag2 = true;
    public bool flag3 = true;
    public bool flag4 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onTime += Time.deltaTime;
        if (onTime >= 10 && flag == true)
        {
            source.PlayOneShot(clip);
            flag = false;
        }
        if (onTime >= 19 && flag2 == true)
        {
            source.PlayOneShot(clip2);
            flag2 = false;
        }
        if (onTime >= 32 && flag3 == true)
        {
            source.PlayOneShot(clip3);
            flag3 = false;
        }
        if (onTime >= 38 && flag4 == true)
        {
            source.PlayOneShot(clip4);
            flag4 = false;
        }
    }
}
