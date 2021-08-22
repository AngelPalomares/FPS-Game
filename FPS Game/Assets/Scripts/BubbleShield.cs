using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    public float Timetodestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timetodestroy -= Time.deltaTime;

        if(Timetodestroy < 1)
        {
            Destroy(gameObject);
        }

    }

    public int HealAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.HealPlayer(HealAmount);
            AudioManager.instance.PlaySFX(10);
        }
    }


}
