using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Second_manager : MonoBehaviour
{
    public int crystals = 319;
    public int firsts = 0;
    public int Second = 0;
    public int ongaku = 0;
    public int Last = 0;
    public int cores = 0;
    public TextMeshProUGUI cry_count;
    public GameObject core;
    public GameObject cwall;
    public GameObject bgm;
    public GameObject LastObjest;
    public GameObject xb;
    public GameObject xb2;
    public GameObject xb4;
    public GameObject portal;
    public Image image;
    public float imageTime;
    public float line;
    public Stage2_perspective fp;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public bool isPlay = true;
    public bool isPlay2 = true;
    public bool isPlay3 = true;
    public bool isPlay4 = true;
    public bool isPlay5 = true;
    public bool isPlay6 = true;
    // Start is called before the first frame update
    void Start()
    {
        core.gameObject.SetActive(false);
        cwall.gameObject.SetActive(true);
        xb.gameObject.SetActive(false);
        xb2.gameObject.SetActive(false);
        xb4.gameObject.SetActive(false);
        LastObjest.gameObject.SetActive(false);
        portal.gameObject.SetActive(false);
        bgm.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
        cry_count.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        imageTime += Time.deltaTime;
        cry_count.text = crystals.ToString();
        if (imageTime >= 10)
        {
            image.gameObject.SetActive(false);
            cry_count.gameObject.SetActive(true);
            fp.PlayGame();
        }
        if (imageTime > 10 && isPlay == true)
        {
            source.PlayOneShot(clip);
            isPlay = false;
        }
        if (crystals < 165 && isPlay2 == true)
        {
            source.PlayOneShot(clip2);
            isPlay2 = false;
        }
        if (isPlay2 == false)
        {
            line += Time.deltaTime;
        }
        if(line >= 4 && isPlay3 == true)
        {
            source.PlayOneShot(clip3);
            isPlay3 = false;
            line = 0;
        }
        if (crystals > 164 && crystals < 319)
        {
            cwall.gameObject.SetActive(true);
        }
        else if(Second != 1)
        {
            cwall.gameObject.SetActive(false);
        }
        if (crystals < 1 && isPlay4 == true)
        {
            source.PlayOneShot(clip4);
            isPlay4 = false;
        }
        if (firsts == 1 && crystals > 164)
        {
            FirstStage();
        }
        else
        {
            firsts = 0;
        }
        if(ongaku == 1)
        {
            bgm.gameObject.SetActive(true);
        }
        if(Second == 1 && crystals > 0)
        {
            SecondStage();
        }
        else
        {
            Second = 0;
        }
        if (firsts != 1)
        {
            xb.gameObject.SetActive(false);
        }
        if(Second != 1)
        {
            xb2.gameObject.SetActive(false);
        }
        if(crystals <= 0 && cores != 1)
        {
            core.gameObject.SetActive(true);
        }
        if (Last == 1)
        {
            xb4.gameObject.SetActive(true);
            portal.gameObject.SetActive(true);
            if (isPlay5 == true)
            {
                source.PlayOneShot(clip5);
                isPlay5 = false;
            }
        }
        if (cores == 1)
        {
            if(isPlay6 == true)
            {
                source.PlayOneShot(clip6);
                isPlay6 = false;
            }
            core.gameObject.SetActive(false);
            source.PlayOneShot(clip6);
            LastObjest.gameObject.SetActive(true);
        }
    }
    public void HikiCrystal()
    {
        crystals--;
    }
    public void StFirst()
    {
        firsts = 1;
    }
    public void FirstStage()
    {
        xb.gameObject.SetActive(true);
    }
    public void SecondStage()
    {
        xb2.gameObject.SetActive(true);
        cwall.gameObject.SetActive(true);
    }
    public void StSecond()
    {
        Second = 1;
    }
    public void StLast()
    {
        Last = 1;
    }
    public void Bgm_start()
    {
        ongaku = 1;
    }
    public void Core()
    {
        if (crystals <= 0)
        {
            cores = 1;
        }
    }
}
