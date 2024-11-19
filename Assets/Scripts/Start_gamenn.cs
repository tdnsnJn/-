using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_gamenn : MonoBehaviour
{
    public Button star;
    // Start is called before the first frame update
    void Start()
    {
        star.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Ballrooms");
            PlayerPrefs.SetInt("skils", 0);
            PlayerPrefs.SetInt("skilflag", 0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
