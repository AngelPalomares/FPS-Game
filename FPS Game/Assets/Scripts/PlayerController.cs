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
    public GameObject Bullet;
    public Transform FirePoint;

    public AudioSource BulletSound,jumpingSound,walkingsound;


    public Gun activeGun;

    public int counter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        //store Y Velocity
        float Ystore = moveInput.y;

        //Moves the character forward
        Vector3 HorizontalMove = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 VerticalMove = transform.forward * Input.GetAxisRaw("Vertical");

        moveInput = HorizontalMove + VerticalMove;
        moveInput.Normalize();
        walkingsound.Play();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveInput = moveInput * RunSpeed;
            Anim.SetFloat("Speed", moveInput.magnitude);

        }
        else
        {
            walkingsound.Play();
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
        if (Input.GetKeyDown(KeyCode.Space)  && canJump || Input.GetKeyDown(KeyCode.Joystick1Button1) && canJump)
        {
            jumpingSound.Play();
            moveInput.y = JumpPower;
            CanDoubleJump = true;
        }
        else if (CanDoubleJump && Input.GetKeyDown(KeyCode.Space) || CanDoubleJump && Input.GetKeyDown(KeyCode.Joystick1Button1) )
        {
            jumpingSound.Play();
            moveInput.y = JumpPower;
            CanDoubleJump = false;
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


        //Shooting Mechanics
        //single shot
        if(Input.GetMouseButtonDown(0) && activeGun.FireCounter <= 0)
        {
            BulletSound.Play();
            RaycastHit hit;

            if(Physics.Raycast(CameraTransform.position,CameraTransform.forward, out hit, 50f))
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

        if(Input.GetMouseButton(0) && activeGun.CanAutoFire)
        {
            if(activeGun.FireCounter <= 0)
            {
                FireShot();
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            counter++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            counter--;
            Debug.Log("working" + counter);
        }

        Anim.SetFloat("Speed", moveInput.magnitude);
        Anim.SetBool("onGround", canJump);
    }

    public void FireShot()
    {
        Instantiate(activeGun.Bullet,FirePoint.position, FirePoint.rotation);

        activeGun.FireCounter = activeGun.FireRate;
    }


}