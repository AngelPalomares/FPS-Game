using System.Collections;
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

    }

    // Update is called once per frame
    void Update()
    {

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

}
