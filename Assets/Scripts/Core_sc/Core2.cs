using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core2 : MonoBehaviour
{
    public Second_manager scm;
    public AudioSource source;
    public AudioClip clip;
    public void OnClick()
    {
        source.PlayOneShot(clip);
        scm.Core();
    }
}
