using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float MoveSpeed;
    public float Lifetime;

    public Rigidbody theRb;

    public GameObject Particles;

    public bool damageEnemy, DamagePlayer;

    public GameObject Headshot;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRb.velocity = transform.forward * MoveSpeed;

        Lifetime -= Time.deltaTime;

        if(Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy" && damageEnemy)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyHealthController>().DamageEnemy();
        }

        if(collision.gameObject.tag == "Head")
        {
            Destroy(collision.transform.parent.gameObject);
        }

        if(collision.gameObject.tag == "Player" && DamagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }

        Destroy(gameObject);
        Instantiate(Particles, transform.position +(transform.forward  * (-MoveSpeed * Time.deltaTime)), transform.rotation);

    }
}
