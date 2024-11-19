using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_chapter : MonoBehaviour
{
    public float mvtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mvtime += Time.deltaTime;
        if(mvtime >= 15)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
