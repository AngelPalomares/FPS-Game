using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth = 5;
    public AudioSource AudioSFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DamageEnemy(int DamageAmount)
    {
        currentHealth -= DamageAmount;

        if(currentHealth <= 0)
        {
            AudioSFX.Play();
            Destroy(gameObject);
        }

    }

    public void Headshot()
    {
        currentHealth = 0;

        if (currentHealth <= 0)
        {
            AudioSFX.Play();
            Destroy(gameObject);
        }
    }



}
