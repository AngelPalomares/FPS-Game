using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text dialogText;
    public Text NameText;

    public GameObject Testing;

    public GameObject DialogBox;
    public GameObject NameBox;

    public string[] dialogLines;
    private bool juststarted;

    public int currentLine;
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
        if(DialogBox.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                Testing.SetActive(false);
                if (!juststarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        DialogBox.SetActive(false);
                    }
                    else
                    {
                        CheckName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    juststarted = false;
                }

            }
        }
    }

    public void ShowDialog(string[] newlines)
    {
        dialogLines = newlines;
        currentLine = 0;
        CheckName();
        dialogText.text = dialogLines[currentLine];
        DialogBox.SetActive(true);
        juststarted = true;
    }

    public void CheckName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            NameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
