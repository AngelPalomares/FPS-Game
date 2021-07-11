using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private static OptionsMenu Instance;
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] Resolutions;

    private int SelectedResolution;

    public Text ResolutionLabel;

    public a

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
}
[System.Serializable]
public class ResItem
{
    public int Horizontal, Vertical;
}
