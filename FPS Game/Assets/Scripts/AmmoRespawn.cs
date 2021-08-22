using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRespawn : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Prefab,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log("There is a bullet inside me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(Prefab,transform.position,transform.rotation);
        }
    }
}
