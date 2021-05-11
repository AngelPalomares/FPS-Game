using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgm;

    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopBGM()
    {
        bgm.Stop();
    }

    public void PlaySFX(int SFXNumber)
    {
        sfx[SFXNumber].Stop();

        sfx[SFXNumber].Play();
    }

    public void StopSFX(int SFXNumber)
    {
        sfx[SFXNumber].Stop();
    }
}
