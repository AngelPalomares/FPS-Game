using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string TheGun;

    private bool Collected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Collected)
        {
            PlayerController.instance.AddGun(TheGun);

            Destroy(gameObject);

            Collected = true;
        }
    }
}
