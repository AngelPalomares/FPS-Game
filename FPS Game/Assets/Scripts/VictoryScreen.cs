using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VictoryScreen : MonoBehaviour
{
    public string MainMenu;

    public float TimeBetweenShowing = 1f;

    public GameObject textBox, returnButtton;

    public Image BlackScreen;

    public float BlackScreenphase = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowObjects());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        BlackScreen.color = new Color(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, Mathf.MoveTowards(BlackScreen.color.a, 0f, BlackScreenphase * Time.deltaTime));
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public IEnumerator ShowObjects()
    {
        yield return new WaitForSeconds(TimeBetweenShowing);

        textBox.SetActive(true);

        yield return new WaitForSeconds(TimeBetweenShowing);

        returnButtton.SetActive(true);

    }
}
