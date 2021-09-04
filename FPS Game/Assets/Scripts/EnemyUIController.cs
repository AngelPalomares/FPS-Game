using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{

    public Slider HealthSlider;

    public Slider HealthSlider2;

    public GameObject Showing;

    public EnemyHealthController Enemy;

    // Start is called before the first frame update
    void Start()
    {
        HealthSlider.maxValue = Enemy.GetComponent<EnemyHealthController>().maxhealth;
        HealthSlider2.maxValue = Enemy.GetComponent<EnemyHealthController>().maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = Enemy.GetComponent<EnemyHealthController>().currentHealth;
        HealthSlider2.value = Enemy.GetComponent<EnemyHealthController>().currentHealth;
    }
}
