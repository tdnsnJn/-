using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballline : MonoBehaviour
{
    public AudioClip st1;
    public AudioClip st2;
    public AudioClip st3;
    public AudioSource source;
    public GameObject portal2;
    public GameObject portal3;
    public bool isOnsei = true;
    public bool isOnsei2 = true;
    // Start is called before the first frame update
    void Start()
    {
        int balls = PlayerPrefs.GetInt("Sinkou");
        portal2.gameObject.SetActive(false);
        portal3.gameObject.SetActive(false);
        if (balls == 0 && isOnsei == true)
        {
            source.PlayOneShot(st1);
            isOnsei = false;
        }
        if(balls == 1 && isOnsei == true)
        {
            portal2.gameObject.SetActive(true);
            source.PlayOneShot(st2);
            isOnsei = false;
        }
        if(balls == 2 && isOnsei2 == true)
        {
            portal2.gameObject.SetActive(true);
            portal3.gameObject.SetActive(true);
            source.PlayOneShot(st3);
            isOnsei2 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
