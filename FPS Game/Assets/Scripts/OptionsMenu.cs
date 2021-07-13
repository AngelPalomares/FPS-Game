using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    private static OptionsMenu Instance;
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] Resolutions;

    private int SelectedResolution;

    public Text ResolutionLabel;

    public AudioMixer themixer;

    public Slider mastSlider, musicSlider, SFXSlider,VoiceSlider;

    public Text MasterLabel, MusicLabel, SFXLabel,VoiceLabel;



    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        //search for resolution in list
        bool foundRes = false;

        for(int i = 0; i < Resolutions.Length; i++)
        {
            if(Screen.width == Resolutions[i].Horizontal && Screen.height == Resolutions[i].Vertical)
            {
                foundRes = true;

                SelectedResolution = i;

                UpdateResLabel();

            }
        }

        if(!foundRes)
        {
            ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            themixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));

            mastSlider.value = PlayerPrefs.GetFloat("MasterVolume");

            MasterLabel.text = (mastSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            themixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

            MusicLabel.text = (musicSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            themixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));

            musicSlider.value = PlayerPrefs.GetFloat("SFXVolume");

            SFXLabel.text = (SFXSlider.value + 80).ToString();
        }

        if (PlayerPrefs.HasKey("VoiceLine"))
        {
            themixer.SetFloat("VoiceLine", PlayerPrefs.GetFloat("VoiceLine"));

            musicSlider.value = PlayerPrefs.GetFloat("VoiceLine");

            MusicLabel.text = (musicSlider.value + 80).ToString();
        }

    }

    void update()
    {

    }

    private void Awake()
    {
        Instance = this;
    }

    public void ResLeft()
    {
        SelectedResolution--;
        if(SelectedResolution < 0)
        {
            SelectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        SelectedResolution++;
        if(SelectedResolution > Resolutions.Length - 1)
        {
            SelectedResolution = Resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        ResolutionLabel.text = Resolutions[SelectedResolution].Horizontal.ToString() + " X " + Resolutions[SelectedResolution].Vertical.ToString();
    }


    public void applyGraphics()
    {
        //apply fullscreen
        //Screen.fullScreen = fullscreenTog.isOn;

        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
            QualitySettings.vSyncCount = 0;

        //set resolution

        Screen.SetResolution(Resolutions[SelectedResolution].Horizontal, Resolutions[SelectedResolution].Vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        MasterLabel.text = (mastSlider.value + 80).ToString();

        themixer.SetFloat("MasterVolume", mastSlider.value);

        PlayerPrefs.SetFloat("MasterVolume", mastSlider.value);
    }

    public void SetMusicVol()
    {
        MusicLabel.text = (musicSlider.value + 80).ToString();

        themixer.SetFloat("MusicVolume", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SetSFXVol()
    {
        SFXLabel.text = (SFXSlider.value + 80).ToString();

        themixer.SetFloat("SFXVolume", SFXSlider.value);

        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void SetVoiceVol()
    {
        VoiceLabel.text = (VoiceSlider.value + 80).ToString();

        themixer.SetFloat("VoiceLine", VoiceSlider.value);

        PlayerPrefs.SetFloat("VoiceLine", VoiceSlider.value);
    }
}
[System.Serializable]
public class ResItem
{
    public int Horizontal, Vertical;
}
