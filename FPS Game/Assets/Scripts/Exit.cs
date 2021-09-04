using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int Ballss;
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.BallCollected.text = "Balls: " + PlayerController.instance.BallGathered + ":171";

        Ballss = GameObject.FindGameObjectsWithTag("Ball").Length;

        if(Ballss == 0)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
