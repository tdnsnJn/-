using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatemaneger : MonoBehaviour
{
    public GameObject stone;
    public AudioClip clip;
    public AudioSource source;
    public bool isflag = true;
    // Start is called before the first frame update
    void Start()
    {
        stone.gameObject.SetActive(false);
        int stage = PlayerPrefs.GetInt("Sinkou");
        if(stage >= 1)
        {
            isflag = false;
            stone.gameObject.SetActive(true);
        }
        if(stage == 0 || isflag == true)
        {
            source.PlayOneShot(clip);
            isflag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
