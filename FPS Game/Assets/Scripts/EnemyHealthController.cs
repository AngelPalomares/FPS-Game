using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth = 5;

    public int maxhealth;

    public EnemyController TheEC;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageEnemy(int DamageAmount)
    {
        currentHealth -= DamageAmount;


        if(TheEC !=null)
        {
            TheEC.GetShot();
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Headshot()
    {
        currentHealth = 0;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



}
