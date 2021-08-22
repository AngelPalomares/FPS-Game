using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform Target, ReturnLook;

    public float rangeToTargetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            transform.LookAt(PlayerController.instance.transform.position + new Vector3(0f,1.0f,0f));
        }
        else
        {
            transform.LookAt(ReturnLook);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
