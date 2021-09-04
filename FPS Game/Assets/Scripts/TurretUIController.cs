using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUIController : MonoBehaviour
{

    public Slider HealthSlider;

    public Slider HealthSlider2;

    public GameObject Showing;

    public TurretHealth Turret;

    // Start is called before the first frame update
    void Start()
    {
        HealthSlider.maxValue = Turret.GetComponent<TurretHealth>().MaxHealth;
        HealthSlider2.maxValue = Turret.GetComponent<TurretHealth>().MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = Turret.GetComponent<TurretHealth>().currentHealth;
        HealthSlider2.value = Turret.GetComponent<TurretHealth>().currentHealth;
    }
}
