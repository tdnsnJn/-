using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_click : MonoBehaviour
{
    public Manager mng;
    public AudioSource source;
    public AudioClip clip;
    public void OnClick()
    {
        source.PlayOneShot(clip);
        mng.Core();
    }
}
