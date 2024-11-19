using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball_manager : MonoBehaviour
{
    public Image skilran;
    public Button not_boost;
    public Image boost;
    public TextMeshProUGUI Skil_abirity;
    public TextMeshProUGUI Skil_ctime;
    public bool hyouji = false;
    // Start is called before the first frame update
    void Start()
    {
        int ski = PlayerPrefs.GetInt("skilflag");
        int skip = PlayerPrefs.GetInt("skils");
        skilran.gameObject.SetActive(false);
        not_boost.gameObject.SetActive(false);
        boost.gameObject.SetActive(false);
        Skil_abirity.gameObject.SetActive(false);
        Skil_ctime.gameObject.SetActive(false);
        not_boost.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("skils", 1);
            boost.gameObject.SetActive(true);
            not_boost.gameObject.SetActive(false);
            Skil_abirity.gameObject.SetActive(true);
            Skil_ctime.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (hyouji == true)
        {
            int skip = PlayerPrefs.GetInt("skils");
            skilran.gameObject.SetActive(true);
            if (skip == 0)
            {
                not_boost.gameObject.SetActive(true);
            }
            if (skip >= 1)
            {
                not_boost.gameObject.SetActive(false);
                boost.gameObject.SetActive(true);
                Skil_abirity.gameObject.SetActive(true);
                Skil_ctime.gameObject.SetActive(true);
                Skil_abirity.text = "SPEED TIME  8.0s";
                Skil_ctime.text = "7.0s";
            }
            
        }
        if(hyouji == false)
        {
            skilran.gameObject.SetActive(false);
            boost.gameObject.SetActive(false);
            Skil_abirity.gameObject.SetActive(false);
            Skil_ctime.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hyouji = false;
        }
    }
    public void OnClick()
    {
        int ski = PlayerPrefs.GetInt("skilflag");
        if (ski >= 1)
        {
            hyouji = true;
        }
    }
}
