using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour
{
    public static FindEnemies instance;
    public GameObject[] Enemies;
    public GameObject prefab;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
