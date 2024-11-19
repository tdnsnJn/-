using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_time : MonoBehaviour
{
    public float nokori;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nokori += Time.deltaTime;
        if(nokori >= 10)
        {
            Destroy(this.gameObject);
        }
    }
}
