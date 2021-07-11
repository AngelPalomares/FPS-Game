using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemies : MonoBehaviour
{
    public GameObject prefab;

    public Transform respawn1, respawn2, respawn3, respawn4;

    public float Countingdown, startcount;

    public int countdown;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        Countingdown = startcount;
    }

    // Update is called once per frame
    void Update()
    {
        RespawnENemies();
        Debug.Log(Countingdown);
    }

    public void RespawnENemies()
    {
        if (FindEnemies.instance.Enemies.Length < 8)
        {
            Countingdown -= Time.deltaTime;

            if (Countingdown <= 0)
            {
                if (countdown <= 0)
                {
                   
                }
                else
                {
                    num = Random.RandomRange(1, 5);
                    Debug.Log(num);
                }

                if (num == 1)
                {
                    if (countdown >= 0)
                    {
                        countdown--;
                        Instantiate(prefab, respawn1);
                        Countingdown = startcount;
                    }
                }
                else if (num == 2)
                {
                    if (countdown >= 0)
                    {
                        countdown--;
                        Instantiate(prefab, respawn2);
                        Countingdown = startcount;
                    }
                }
                else if (num == 3)
                {
                    if (countdown >= 0)
                    {
                        countdown--;
                        Instantiate(prefab, respawn3);
                        Countingdown = startcount;
                    }
                }
                else if (num == 4)
                {
                    if (countdown >= 0)
                    {
                        countdown--;
                        Instantiate(prefab, respawn4);
                        Countingdown = startcount;
                    }
                }
            }
        }
    }
}
