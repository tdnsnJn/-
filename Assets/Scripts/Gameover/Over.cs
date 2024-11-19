using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour
{
    public Button rt;
    public Button ti;
    // Start is called before the first frame update
    void Start()
    {
        rt.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
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
