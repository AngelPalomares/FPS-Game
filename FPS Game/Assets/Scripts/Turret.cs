using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Bullet;

    public float rangeToTargetPlayer, TimeBetweenShots = .5f;
    private float ShotCounter;

    public Transform Gun, FirePoint;

    public float RotateSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        ShotCounter = TimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position)< rangeToTargetPlayer)
        {
            Gun.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 1.2f, 0f));

            ShotCounter -= Time.deltaTime;
            if(ShotCounter <= 0)
            {
                Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                ShotCounter = TimeBetweenShots;
            }
        }
        else
        {
            ShotCounter = TimeBetweenShots;

            Gun.rotation = Quaternion.Lerp(Gun.rotation, Quaternion.Euler(0f, Gun.rotation.eulerAngles.y + 10f, 0f),RotateSpeed * Time.deltaTime);
        }
    }
}
