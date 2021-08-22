using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSounds : MonoBehaviour
{
    
    public AudioSource SpookyMusic;

    public float rangeToTargetPlayer;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            SpookyMusic.Play();
        }
        else
        {
            SpookyMusic.Stop();
        }
    }
    
}
