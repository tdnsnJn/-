using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_manager : MonoBehaviour
{
    public Button Gs;
    public Button Re;
    public Button Secret;
    public Button Exit;
    public Button credit;
    public SpriteRenderer ti1;
    public SpriteRenderer ti2;
    public SpriteRenderer ti3;
    // Start is called before the first frame update
    void Start()
    {
        ti1.enabled = true;
        ti2.enabled = false;
        ti3.enabled = false;
        int stage = PlayerPrefs.GetInt("Sinkou");
        if(stage == 1)
        {
            ti1.enabled = false;
            ti2.enabled = true;
            ti3.enabled = false;
        }
        if(stage == 2)
        {
            ti1.enabled = false;
            ti2.enabled = false;
            ti3.enabled = true;
        }
        Gs.onClick.AddListener(() =>
        {
            if(stage == 0)
            {
                SceneManager.LoadScene("Story");
            }
            if(stage >= 1)
            {
               SceneManager.LoadScene("Ballrooms");
            }
        });
        Re.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Retry");
        });
        Secret.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Secret_scene");
        });
        credit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Cresit");
        });
        Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
