using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
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
        if (other.tag == "Sword")
        {
            Debug.Log("Box is on top of me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
            Debug.Log("Button is no longer there");
    }
}
