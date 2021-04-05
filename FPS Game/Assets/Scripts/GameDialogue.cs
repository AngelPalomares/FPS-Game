using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialogue : MonoBehaviour
{
    public string NPC;
    public string Message;

    public string secondMessage;

    public bool FisrtMission;

    public int next;

    public int annoying;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("first if statement");
            UIController.instance.TextToSetActive.SetActive(false);

            SwitchDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIController.instance.TextToSetActive.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UIController.instance.TextToSetActive.SetActive(false);
        UIController.instance.MessageObject.SetActive(false);
        UIController.instance.Nameobject.SetActive(false);
        next = 0;
        annoying = 0;
    }

    public void SwitchDialogue()
    {
        next++;

        if(next == 3)
        {
            next = 1;
        }

        if(next == 1)
        {
            annoying++;
            UIController.instance.Name.text = "Miguel";
            UIController.instance.Nameobject.SetActive(true);
            UIController.instance.Message.text = "reading";
            UIController.instance.MessageObject.SetActive(true);
        }
        else if(next == 2)
        {
            annoying++;
            UIController.instance.Message.text = "still reading motherfucker";
            UIController.instance.MessageObject.SetActive(true);
        }

        if(annoying == 8)
        {
            UIController.instance.Message.text = "Stop fucking around and continue playing the game";
            next = 0;
        }

    }

}
