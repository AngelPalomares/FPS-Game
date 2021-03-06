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

    public AudioSource[] TestingifWorks;

    public int currentLine;
    public int currentVoice;
    public int onelessvoice;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (DialogBox.activeInHierarchy)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Testing.SetActive(false);

                if (!juststarted)
                {
                    currentLine++;
                    currentVoice++;
                    onelessvoice = currentVoice - 1;

                    if (currentLine >= dialogLines.Length)
                    {
                        DialogBox.SetActive(false);
                    }
                    else
                    {
                        CheckName();
                        dialogText.text = dialogLines[currentLine];
                    }

                    if (currentVoice == 1)
                    {
                        TestingifWorks[onelessvoice].Stop();
                        ContinuePlayingVoice(currentVoice);
                    }
                    else if (currentVoice == 2)
                    {
                        TestingifWorks[onelessvoice].Stop();
                        ContinuePlayingVoice(currentVoice);
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

    public void PlayVoice(AudioSource[] Voice)
    {
        TestingifWorks = Voice;
        currentVoice = 0;
        TestingifWorks[currentVoice].Stop();

        TestingifWorks[currentVoice].Play();
    }

    public void ContinuePlayingVoice(int c)
    {
        TestingifWorks[c].Stop();
        TestingifWorks[c].Play();
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