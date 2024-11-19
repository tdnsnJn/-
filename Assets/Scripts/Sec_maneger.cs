using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sec_maneger : MonoBehaviour
{
    public Button sb;
    public Button sb2;
    public Button sb3;
    public Button sb4;
    public Button sb5;
    public Button sb6;
    public Button sb7;
    public Button title;
    public Sprite[] imagesec;
    public Image hyoji;
    public Button modori;
    // Start is called before the first frame update
    void Start()
    {
        sb.gameObject.SetActive(false);
        sb2.gameObject.SetActive(false);
        sb3.gameObject.SetActive(false);
        sb4.gameObject.SetActive(false);
        sb5.gameObject.SetActive(false);
        sb6.gameObject.SetActive(false);
        sb7.gameObject.SetActive(false);
        modori.gameObject.SetActive(false);
        title.gameObject.SetActive(true);
        hyoji.gameObject.SetActive(false);
        int secb = PlayerPrefs.GetInt("sec");
        int secb2 = PlayerPrefs.GetInt("sec2");
        if(secb == 3)
        {
            sb.gameObject.SetActive(true);
            sb2.gameObject.SetActive(true);
            sb3.gameObject.SetActive(true);
        }
        else if(secb == 2)
        {
            sb.gameObject.SetActive(true);
            sb2.gameObject.SetActive(true);
        }
        else if(secb == 1)
        {
            sb.gameObject.SetActive(true);
        }
        if(secb2 == 4)
        {
            sb4.gameObject.SetActive(true);
            sb5.gameObject.SetActive(true);
            sb6.gameObject.SetActive(true);
            sb7.gameObject.SetActive(true);
        }
        else if (secb2 == 3)
        {
            sb4.gameObject.SetActive(true);
            sb5.gameObject.SetActive(true);
            sb6.gameObject.SetActive(true);
        }
        else if (secb2 == 2)
        {
            sb4.gameObject.SetActive(true);
            sb5.gameObject.SetActive(true);
        }
        else if (secb2 == 1)
        {
            sb4.gameObject.SetActive(true);
        }
        sb.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[0];
        });
        sb2.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[1];
        });
        sb3.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[2];
        });
        sb4.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[3];
        });
        sb5.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[4];
        });
        sb6.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[5];
        });
        sb7.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(true);
            modori.gameObject.SetActive(true);
            title.gameObject.SetActive(false);
            hyoji.sprite = imagesec[6];
        });
        modori.onClick.AddListener(() =>
        {
            hyoji.gameObject.SetActive(false);
            modori.gameObject.SetActive(false);
            title.gameObject.SetActive(true);
        });
        title.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
