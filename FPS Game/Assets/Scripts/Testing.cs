using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float RunSpeed;
    public float Gravity;
    public float MouseSensitivity;

    public LayerMask WhatIsGround;

    public Transform GroundToCheck;
    public Transform CameraLocation;

    private Vector3 MoveInput;

    private bool InvertX;
    private bool InvertY;
    private bool CanJump;
    private bool CanDoubleJump;

    public CharacterController ControllingTheCharacter;

    public GameObject Buller;
    public Transform GunLocation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Ystore = MoveInput.y;

        Vector3 MoveHorizontal = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 MoveVertical = transform.forward * Input.GetAxisRaw("Vertical");

        MoveInput = MoveHorizontal + MoveVertical;
        MoveInput.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveInput = MoveInput * RunSpeed;
        }
        else
        {
            MoveInput = MoveInput * MoveSpeed;
        }

        MoveInput.y = Ystore;
        MoveInput.y += Physics.gravity.y * Gravity * Time.deltaTime;

        if(ControllingTheCharacter.isGrounded)
        {
            MoveInput.y = Physics.gravity.y * Gravity * Time.deltaTime;
        }

        CanJump = Physics.OverlapSphere(GroundToCheck.position, 0.25f, WhatIsGround).Length > 0;

        if(CanJump)
        {
            CanDoubleJump = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            MoveInput.y = JumpForce;
            CanDoubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && CanDoubleJump)
        {
            MoveInput.y = JumpForce;
            CanDoubleJump = false;
        }

        ControllingTheCharacter.Move(MoveInput * Time.deltaTime);

        Vector2 MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + MouseInput.x, transform.rotation.eulerAngles.z);

        CameraLocation.rotation = Quaternion.Euler(CameraLocation.rotation.eulerAngles + new Vector3(-MouseInput.y, 0f, 0f));

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Buller, GunLocation.position, GunLocation.rotation);
        }




    }
}
