﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    public int currentHealth = 5;
    public AudioSource AudioSFX;
    public GameObject Prefab;


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

        if (currentHealth <= 0)
        {
            AudioSFX.Play();
            Instantiate(Prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
