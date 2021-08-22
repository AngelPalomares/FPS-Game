using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCube : MonoBehaviour
{
    public GameObject testing;
    public GameObject testing2;
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
        if(other.tag == "Sword")
        {
            testing.SetActive(true);
            testing2.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sword")
        {
            testing.SetActive(false);
            testing2.SetActive(true);
        }
    }
}
