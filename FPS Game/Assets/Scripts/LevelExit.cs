using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string LevelToLoad;

    public float WaitToEndLevel;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;
            StartCoroutine(EndLevelCo());
            AudioManager.instance.PlayLevelVictory();
        }
    }

    private IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(LevelToLoad + "_cp", "");
        yield return new WaitForSeconds(WaitToEndLevel);
        SceneManager.LoadScene(LevelToLoad);
    }
}
