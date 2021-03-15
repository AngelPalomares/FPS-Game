using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private bool chasing;
    public float distanceToChase, DistanceToLose, distanceToStop = 2f;

    private Vector3 targetPoint, startpoint;

    public NavMeshAgent TheMesh;

    public float keepChasingTime = 5f;

    private float ChaseCounter;

    public GameObject Bullet;
    public Transform firepoint;

    public float fireRate, waitBetweemShots = 2f,TimeToShoot = 1f;
    private float FireCount,ShotWaitCounter,ShootTimeCounter;

    public Animator Anime;

    // Start is called before the first frame update
    void Start()
    {
        startpoint = transform.position;
        ShootTimeCounter = TimeToShoot;
        ShotWaitCounter = waitBetweemShots;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        targetPoint.y = transform.position.y;


        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                chasing = true;

                ShootTimeCounter = TimeToShoot;
                ShotWaitCounter = waitBetweemShots;
            }

            //if chase is true go to last known player position
            if (ChaseCounter > 0)
            {
                ChaseCounter -= Time.deltaTime;

                if (ChaseCounter <= 0)
                {
                    TheMesh.destination = startpoint;
                }
            }

            if(TheMesh.remainingDistance <.25f)
            {
                Anime.SetBool("isMoving", false);
            }
            else
            {
                Anime.SetBool("isMoving", true);
            }


        }
        else
        {
            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                TheMesh.destination = targetPoint;
            }else
            {
                TheMesh.destination = transform.position;
            }

            if(Vector3.Distance(transform.position,targetPoint) > DistanceToLose)
            {
                chasing = false;
                TheMesh.destination = startpoint;

                ChaseCounter = keepChasingTime;
            
            }

            if (ShotWaitCounter > 0)
            {
                ShotWaitCounter -= Time.deltaTime;

                if(ShotWaitCounter <= 0)
                {
                    ShootTimeCounter = TimeToShoot;
                }

                Anime.SetBool("isMoving", true);

            }
            else
            {
                ShootTimeCounter -= Time.deltaTime;

                if (ShootTimeCounter > 0)
                {
                    FireCount -= Time.deltaTime;

                    if (FireCount <= 0)
                    {
                        FireCount = fireRate;

                        firepoint.LookAt(PlayerController.instance.transform.position + new Vector3 (0f,1.5f, 0f));

                        //check the angle to the player
                        Vector3 targetDir = PlayerController.instance.transform.position - transform.position;

                        float angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

                        if(Mathf.Abs(angle) < 30f)
                        {
                            Instantiate(Bullet, firepoint.position, firepoint.rotation);
                            Anime.SetTrigger("FireShot");
                        }
                        else
                        {
                            ShotWaitCounter = waitBetweemShots;
                        }


                    }
                    TheMesh.destination = transform.position;
                }
                else
                {
                    ShotWaitCounter = waitBetweemShots;
                }

                Anime.SetBool("isMoving", false);
            }

            

        }
    }
}
