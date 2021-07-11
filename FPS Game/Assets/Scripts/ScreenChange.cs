using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChange: MonoBehaviour
{
    public string mainmenuScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        GameManager.instance.PauseUnPause();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainmenuScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
