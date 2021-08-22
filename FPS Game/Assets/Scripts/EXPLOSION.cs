using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLOSION : MonoBehaviour
{

    public int damage = 25;

    public bool damageEnemy, DamagePlayer;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && damageEnemy)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
        }

        if (collision.gameObject.tag == "Player" && DamagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }

    }
}
