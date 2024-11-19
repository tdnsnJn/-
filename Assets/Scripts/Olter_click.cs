using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Olter_click : MonoBehaviour
{
    public int slik;
    public int flags;
    public Image Skillan;
    public Image Boost;
    public Button skl;
    // Start is called before the first frame update
    void Start()
    {
        slik = PlayerPrefs.GetInt("Sinkou");
        flags = PlayerPrefs.GetInt("skilflag");
        Skillan.gameObject.SetActive(false);
        skl.onClick.AddListener(() =>
        {
            if(flags >= 1)
            {
                PlayerPrefs.SetInt("skils",1);
            }
        });
    }
    public void OnClick()
    {
        if(slik >= 1 && flags >= 1)
        {
            Skillan.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
