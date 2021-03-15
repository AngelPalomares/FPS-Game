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

            if (CurrentHealth <= 0)
            {
                gameObject.SetActive(false);
            }

            invicibleCounter = invincibleLenght;
        }

    }

}
