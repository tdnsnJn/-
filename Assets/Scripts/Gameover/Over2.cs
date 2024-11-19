using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Over2 : MonoBehaviour
{
    public Button rt;
    public Button ti;
    // Start is called before the first frame update
    void Start()
    {
        rt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Second_scene");
        });
        ti.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
