using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialogue : MonoBehaviour
{
    public static GameDialogue instance;

    public string[] lines;
    public AudioSource[] Voicelines;

    private bool canActivate;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetKeyDown(KeyCode.E) && !DialogueManager.instance.DialogBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialog(lines);
            DialogueManager.instance.PlayVoice(Voicelines);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DialogueManager.instance.Testing.SetActive(true);
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            DialogueManager.instance.Testing.SetActive(false);
            canActivate = false;
        }    
    }

}
