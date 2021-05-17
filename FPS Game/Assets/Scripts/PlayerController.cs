using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //speed of the player
    [SerializeField]
    private float MoveSpeed;

    //gravity of the player
    //new
    [SerializeField]
    private float Gravity;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private float RunSpeed = 12;

    public CharacterController charCon;
    private Vector3 moveInput;
    public Transform CameraTransform;
    public float MouseSensitivity;
    public bool InvertX;
    public bool inverY;
    private bool RunBoyRun;
    private bool Running;

    //new
    private bool canJump;

    private bool CanDoubleJump;
    public Transform GroundCheckPoint;
    public LayerMask WhatIsGround;

    public Animator Anim;

    //gun COntrol
    //public GameObject Bullet;
    public Transform FirePoint;

    public AudioSource BulletSound,jumpingSound,walkingsound;


    public Gun activeGun;

    public List<Gun> allguns = new List<Gun>();
    public List<Gun> unlockableGuns = new List<Gun>();

    public int currentGun;

    public Transform ADSPoint, GunHolder;
    private Vector3 gunStartPOS;
    public float ADSSpeed = 2;

    public GameObject MuzzleFlash;

    public bool Swingoff;

    public AudioSource footstepFast, FootstepSlow;

    private float BounceAmount;
    private bool Bouncebool;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentGun--;

        SwitchGun();

        gunStartPOS = GunHolder.localPosition;

    }

    // Update is called once per frame
    private void Update()
    {
        if (!UIController.instance.PauseScreen.activeInHierarchy)
        {
            //store Y Velocity
            float Ystore = moveInput.y;

            //Moves the character forward
            Vector3 HorizontalMove = transform.right * Input.GetAxisRaw("Horizontal");
            Vector3 VerticalMove = transform.forward * Input.GetAxisRaw("Vertical");

            moveInput = HorizontalMove + VerticalMove;
            moveInput.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = moveInput * RunSpeed;
                Anim.SetFloat("Speed", moveInput.magnitude);

            }
            else
            {
                moveInput = moveInput * MoveSpeed;
                Anim.SetFloat("Speed", moveInput.magnitude);
            }

            //applies Gravity
            moveInput.y = Ystore;
            moveInput.y += Physics.gravity.y * Gravity * Time.deltaTime;

            if (charCon.isGrounded)
            {
                moveInput.y = Physics.gravity.y * Gravity * Time.deltaTime;
            }

            canJump = Physics.OverlapSphere(GroundCheckPoint.position, .25f, WhatIsGround).Length > 0;

            if (canJump)
            {
                CanDoubleJump = false;
            }

            //HandleJumping
            if (Input.GetKeyDown(KeyCode.Space) && canJump || Input.GetKeyDown(KeyCode.Joystick1Button1) && canJump)
            {
                jumpingSound.Play();
                moveInput.y = JumpPower;
                CanDoubleJump = true;

                AudioManager.instance.PlaySFX(13);
            }
            else if (CanDoubleJump && Input.GetKeyDown(KeyCode.Space) || CanDoubleJump && Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                jumpingSound.Play();
                moveInput.y = JumpPower;
                CanDoubleJump = false;
                AudioManager.instance.PlaySFX(13);
            }

            if (Bouncebool)
            {
                Bouncebool = false;
                moveInput.y = BounceAmount;

                CanDoubleJump = true;
            }

            //allows the character to move by the given values that were set
            charCon.Move(moveInput * Time.deltaTime);

            //Controlling the Camera Rotation
            Vector2 MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * MouseSensitivity;

            if (InvertX)
            {
                MouseInput.x = -MouseInput.x;
            }
            if (inverY)
            {
                MouseInput.y = -MouseInput.y;
            }

            //Rotates the Player
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + MouseInput.x, transform.rotation.eulerAngles.z);

            //Moves the camera up and down
            CameraTransform.rotation = Quaternion.Euler(CameraTransform.rotation.eulerAngles + new Vector3(-MouseInput.y, 0f, 0f));

            MuzzleFlash.SetActive(false);

            //Shooting Mechanics
            //single shot
            if (Input.GetMouseButtonDown(0) && activeGun.FireCounter <= 0)
            {
                RaycastHit hit;

                if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, 50f))
                {
                    if (Vector3.Distance(CameraTransform.position, hit.point) > 2f)
                    {
                        FirePoint.LookAt(hit.point);
                    }
                }
                else
                {
                    FirePoint.LookAt(CameraTransform.position + (CameraTransform.forward * 30f));
                }

                //Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                FireShot();
            }




            //repeats shots

            if (Input.GetMouseButton(0) && activeGun.CanAutoFire)
            {
                if (activeGun.FireCounter <= 0)
                {
                    FireShot();
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                SwitchGun();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                ReverseSwitchGun();
            }

            if (Input.GetMouseButton(1))
            {
                CameraController.instance.ZoomIn(activeGun.ZoomAmount);
            }

            if (Input.GetMouseButton(1))
            {
                GunHolder.position = Vector3.MoveTowards(GunHolder.position, ADSPoint.position, ADSSpeed * Time.deltaTime);
            }
            else
            {
                GunHolder.localPosition = Vector3.MoveTowards(GunHolder.localPosition, gunStartPOS, ADSSpeed * Time.deltaTime);
            }

            if (Input.GetMouseButtonUp(1))
            {
                CameraController.instance.ZoomOut();
            }

            /*

            if(Input.GetKeyDown(KeyCode.F))
            {
                Anim.SetBool("Fbutton", true);
                StartCoroutine(MeleeCo());
            }
            */

            Anim.SetFloat("Speed", moveInput.magnitude);
            Anim.SetBool("onGround", canJump);

        }
    }

    public void FireShot()
    {
        if (activeGun.CurrentAmmo > 0)
        {
            activeGun.CurrentAmmo--;
            Instantiate(activeGun.Bullet, FirePoint.position, FirePoint.rotation);

            activeGun.FireCounter = activeGun.FireRate;
            UIController.instance.AmmoText.text = "AMMO: " + activeGun.CurrentAmmo;

            MuzzleFlash.SetActive(true);
        }
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);
        currentGun++;

        if(currentGun >= allguns.Count)
        {
            currentGun = 0;
        }

        activeGun = allguns[currentGun];
        activeGun.gameObject.SetActive(true);

        UIController.instance.AmmoText.text = "AMMO: " + activeGun.CurrentAmmo;

        FirePoint.position = activeGun.FirePoint.position;

        if (currentGun == 0)
        {
            Gun.instance.PistolCrosshair.SetActive(true);
            Gun.instance.MachineGunCrossHair.SetActive(false);
            Gun.instance.SniperCrossHair.SetActive(false);
        }
        else if (currentGun == 1)
        {
            Gun.instance.PistolCrosshair.SetActive(false);
            Gun.instance.MachineGunCrossHair.SetActive(true);
            Gun.instance.SniperCrossHair.SetActive(false);
        }
        else if (currentGun == 2)
        {
            Gun.instance.PistolCrosshair.SetActive(false);
            Gun.instance.MachineGunCrossHair.SetActive(false);
            Gun.instance.SniperCrossHair.SetActive(true);
        }
    }

    public void ReverseSwitchGun()
    {
        activeGun.gameObject.SetActive(false);
        currentGun--;

        if (currentGun <= -1)
        {
            currentGun = allguns.Count - 1;
        }

        activeGun = allguns[currentGun];
        activeGun.gameObject.SetActive(true);

        UIController.instance.AmmoText.text = "AMMO: " + activeGun.CurrentAmmo;

        FirePoint.position = activeGun.FirePoint.position;

        if (currentGun == 0)
        {
            Gun.instance.PistolCrosshair.SetActive(true);
            Gun.instance.MachineGunCrossHair.SetActive(false);
            Gun.instance.SniperCrossHair.SetActive(false);
        }
        else if (currentGun == 1)
        {
            Gun.instance.PistolCrosshair.SetActive(false);
            Gun.instance.MachineGunCrossHair.SetActive(true);
            Gun.instance.SniperCrossHair.SetActive(false);
        }
        else if (currentGun == 2)
        {
            Gun.instance.PistolCrosshair.SetActive(false);
            Gun.instance.MachineGunCrossHair.SetActive(false);
            Gun.instance.SniperCrossHair.SetActive(true);
        }

    }

    public void AddGun(string guntoadd)
    {
        bool gunUnlocked = false;

        if(unlockableGuns.Count > 0)
        {
            for(int i = 0; i < unlockableGuns.Count; i++)
            {
                if(unlockableGuns[i].GunName == guntoadd)
                {
                    gunUnlocked = true;

                    allguns.Add(unlockableGuns[i]);

                    unlockableGuns.RemoveAt(i);

                    i = unlockableGuns.Count;
                }
            }
        }

        if(gunUnlocked)
        {
            currentGun = allguns.Count - 2;
            SwitchGun();
        }

    }

    public void Bounce(float BounceForce)
    {
        BounceAmount = BounceForce;
        Bouncebool = true;
    }
    /*
    public IEnumerator MeleeCo()
    {
        yield return new WaitForSeconds(0.15f);
        Anim.SetBool("Fbutton", false);
    }
    */



}