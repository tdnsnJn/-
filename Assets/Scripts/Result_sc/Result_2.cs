using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Result_2 : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI CryText;
    public TextMeshProUGUI SecText;
    public TextMeshProUGUI DssText;
    public TextMeshProUGUI RrcText;
    public TextMeshProUGUI TotalText;
    public int sour;
    public Button title;
    public Button next;
    // Start is called before the first frame update
    void Start()
    {
        title.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        sour = PlayerPrefs.GetInt("st2runk");
        title.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });
        next.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Ballrooms");
        });
    }

    // Update is called once per frame
    void Update()
    {
        CryText.text = "S";
        //時間
        if (Result_num.Rtime <= 600)
        {
            TimeText.text = "S";
        }
        else if (Result_num.Rtime > 600 && Result_num.Rtime <= 720)
        {
            TimeText.text = "A";
        }
        else if (Result_num.Rtime > 720 && Result_num.Rtime <= 940)
        {
            TimeText.text = "B";
        }
        else if (Result_num.Rtime > 940 && Result_num.Rtime <= 1160)
        {
            TimeText.text = "C";
        }
        else if (Result_num.Rtime > 1160)
        {
            TimeText.text = " ";
        }
        //シークレット
        if (Result_num.Rsec == 4)
        {
            SecText.text = "S";
        }
        else if (Result_num.Rsec == 3)
        {
            SecText.text = "A";
        }
        else if (Result_num.Rsec == 2)
        {
            SecText.text = "B";
        }
        else if (Result_num.Rsec == 1)
        {
            SecText.text = "C";
        }
        else if (Result_num.Rsec == 0)
        {
            SecText.text = " ";
        }
        //デス回数
        if (Result_num.Rdss == 0)
        {
            DssText.text = "S";
        }
        else if (Result_num.Rdss == 1)
        {
            DssText.text = "A";
        }
        else if (Result_num.Rdss == 2)
        {
            DssText.text = "B";
        }
        //連続取得回数
        if (Result_num.Rrc >= 250)
        {
            RrcText.text = "S";
        }
        else if (Result_num.Rrc >= 150 && Result_num.Rrc < 250)
        {
            RrcText.text = "A";
        }
        else if (Result_num.Rrc >= 100 && Result_num.Rrc < 150)
        {
            RrcText.text = "B";
        }
        else if (Result_num.Rrc < 100)
        {
            RrcText.text = "C";
        }
        if (Result_num.Rtime <= 600 && Result_num.Rsec == 4 && Result_num.Rdss == 0 && Result_num.Rrc >= 250)
        {
            TotalText.text = "S";
            if(sour < 4)
            {
                PlayerPrefs.SetInt("st2runk", 4);
            }
        }
        else if (Result_num.Rtime > 1140 && Result_num.Rdss == 2 && Result_num.Rsec == 0 && Result_num.Rrc < 100)
        {
            TotalText.text = "C";
            if (sour < 1)
            {
                PlayerPrefs.SetInt("st2runk", 1);
            }
        }
        else if (TimeText.text == "A" || SecText.text == "A" || DssText.text == "A" || RrcText.text == "A")
        {
            TotalText.text = "A";
            if (sour <= 2)
            {
                PlayerPrefs.SetInt("st2runk", 3);
            }
        }
        else
        {
            TotalText.text = "B";
            if (sour <= 1)
            {
                PlayerPrefs.SetInt("st2runk", 2);
            }
        }
    }
}

