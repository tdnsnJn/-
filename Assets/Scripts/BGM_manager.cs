using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_manager : MonoBehaviour
{
    public AudioSource source;
    AudioClip playBGM;
    int playBGMNum;
    public List<AudioClip> BGMList;
    // Start is called before the first frame update
    void Start()
    {
        playBGMNum = -1;
        PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBGM(int Bgmnum)
    {
        if (playBGMNum == Bgmnum) return;

        Debug.Log($"bgm > {Bgmnum}");
        playBGM = BGMList[Bgmnum];
        source.clip = playBGM;
        source.Play();

        playBGMNum = Bgmnum;
    }
}
