using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float BounceForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.Bounce(BounceForce);
            AudioManager.instance.PlaySFX(5);
        }
    }
}
