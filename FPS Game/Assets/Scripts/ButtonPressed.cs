using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public Animator anim;
    public bool ButtonPre;

    public GameObject buttonPressed, ButtonUp;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            buttonPressed.SetActive(true);
            //ButtonUp.SetActive(false);
            
            
            ButtonPre = true;
            anim.SetBool("IsDown", true);
            Debug.Log("Box is on top of me");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            
            buttonPressed.SetActive(false);
            //ButtonUp.SetActive(true);
            
            
            ButtonPre = false;
            anim.SetBool("IsDown", false);
            Debug.Log("Button is no longer there");
            
        }
    }
}
