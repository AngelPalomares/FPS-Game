using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
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
        if(other.tag == "Sword")
        {
            Debug.Log("sword Hit");
        }

        if(other.tag == "Player")
        {
            Debug.Log("I sense the player");
        }    
    }
}
