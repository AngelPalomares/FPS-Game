﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;

    public bool CanAutoFire;

    public float FireRate;

    [HideInInspector]
    public float FireCounter;


    public int CurrentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FireCounter > 0)
        {
            FireCounter -= Time.deltaTime;
        }
    }
}
