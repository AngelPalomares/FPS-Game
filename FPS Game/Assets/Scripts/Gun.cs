using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public static Gun instance;

    public GameObject Bullet;

    public bool CanAutoFire;

    public float FireRate;

    [HideInInspector]
    public float FireCounter;


    public int CurrentAmmo, pickupAmount;

    public Transform FirePoint;

    public float ZoomAmount;

    public GameObject PistolCrosshair;

    public GameObject MachineGunCrossHair;

    public GameObject SniperCrossHair;

    public GameObject RocketLauncherCrossHair;

    public string GunName;

    private void Awake()
    {
        instance = this;
    }

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

    public void GetAmmo()
    {
        CurrentAmmo += pickupAmount;

        UIController.instance.AmmoText.text = "AMMO: " + CurrentAmmo;

    }
}
