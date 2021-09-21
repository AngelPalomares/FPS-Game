using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static MainMenu Instance;
    public GameObject ActivateOptions;
    public string FirstLevel;
    public GameObject ContinueButton;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            ContinueButton.SetActive(true);
        }
        else
        {
            ContinueButton.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        if(PlayerPrefs.GetString("CurrentLevel") == "")
        {
            ContinueButton.SetActive(false);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(FirstLevel);
        PlayerPrefs.SetString("CurrentLevel", "");
        PlayerPrefs.SetString(FirstLevel + "_cp", "");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        ActivateOptions.SetActive(true);
    }

    public void CloseSettings()
    {
        ActivateOptions.SetActive(false);
    }

    public void Clearsettings()
    {
        PlayerPrefs.DeleteAll();
    }
}
