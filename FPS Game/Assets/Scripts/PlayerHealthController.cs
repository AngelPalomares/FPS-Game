using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int MaxHealth, CurrentHealth;

    public float invincibleLenght = 1f;

    private float invicibleCounter;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;

        UIController.instance.healthSlider.maxValue = MaxHealth;
        UIController.instance.healthSlider.value = CurrentHealth;
        UIController.instance.healthText.text = "HEALTH: " + CurrentHealth + "/" + MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageamount)
    {
        if (invicibleCounter <= 0)
        {
            CurrentHealth -= damageamount;

            UIController.instance.ShowDamage();

            if (CurrentHealth <= 0)
            {
                gameObject.SetActive(false);

                CurrentHealth = 0;

                GameManager.instance.PlayerDied();

                AudioManager.instance.StopBGM();

            }

            invicibleCounter = invincibleLenght;

            UIController.instance.healthSlider.value = CurrentHealth;
            UIController.instance.healthText.text = "HEALTH: " + CurrentHealth + "/" + MaxHealth;

        }

    }

    public void HealPlayer(int healamount)
    {
        CurrentHealth += healamount;

        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        UIController.instance.healthSlider.value = CurrentHealth;
        UIController.instance.healthText.text = "HEALTH: " + CurrentHealth + "/" + MaxHealth;

    }

}
