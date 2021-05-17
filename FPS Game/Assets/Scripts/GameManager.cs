﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float WaitAfterDying = 2f;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(PlayerDiedCo());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(WaitAfterDying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnPause()
    {
        if(UIController.instance.PauseScreen.activeInHierarchy)
        {
            UIController.instance.PauseScreen.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1f;

            PlayerController.instance.footstepFast.Play();
            PlayerController.instance.FootstepSlow.Play();

        }
        else
        {
            UIController.instance.PauseScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0f;

            PlayerController.instance.footstepFast.Stop();
            PlayerController.instance.FootstepSlow.Stop();
        }
    }

}
