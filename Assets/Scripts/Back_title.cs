using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_title : MonoBehaviour
{
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
