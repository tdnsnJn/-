using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Retry_maneger : MonoBehaviour
{
    public Button st;
    public Button st2;
    public Button Title;
    public TextMeshProUGUI st1r;
    public TextMeshProUGUI st1n;
    public TextMeshProUGUI st2r;
    public TextMeshProUGUI st2n;

    // Start is called before the first frame update
    void Start()
    {
        st.gameObject.SetActive(false);
        st1n.gameObject.SetActive(false);
        st2.gameObject.SetActive(false);
        st2n.gameObject.SetActive(false);
        st1r.text = "";
        st2r.text = "";
        int stage = PlayerPrefs.GetInt("Sinkou");
        int st1run = PlayerPrefs.GetInt("st1runk");
        int st2run = PlayerPrefs.GetInt("st2runk");
        if (stage >= 1)
        {
            st.gameObject.SetActive(true);
            st1n.gameObject.SetActive(true);
        }
        if(stage >= 2)
        {
            st2.gameObject.SetActive(true);
            st2n.gameObject.SetActive(true);
        }
        if(st1run == 4)
        {
            st1r.text = "S";
        }
        else if(st1run == 3)
        {
            st1r.text = "A";
        }
        else if (st1run == 2)
        {
            st1r.text = "B";
        }
        else if (st1run == 1)
        {
            st1r.text = "C";
        }
        if (st2run == 4)
        {
            st2r.text = "S";
        }
        else if (st2run == 3)
        {
            st2r.text = "A";
        }
        else if (st2run == 2)
        {
            st2r.text = "B";
        }
        else if (st2run == 1)
        {
            st2r.text = "C";
        }
        st.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("SampleScene");
        });
        st2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Second_scene");
        });
        Title.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
