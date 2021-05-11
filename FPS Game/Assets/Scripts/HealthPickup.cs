using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int HealAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.HealPlayer(HealAmount);
            AudioManager.instance.PlaySFX(10);
            Destroy(gameObject);
        }
    }

}
