using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Singleton
    public static PlayerController instance;
    //Player movement
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5f;
    private float rotateSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    //Player jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;
    public float jump = 5;
    //Player Animation
    Animator playerAnimator;
    private bool isWalking = false;

    //Projectile Bullets
    public GameObject bullet;
    public Transform projectilePos;
    public int playerHealth = 4;

    // Enable and Disable player actions script
    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        // Unity's input action system
        inputAction = new PlayerAction();
        // checks if player pressed or released W & S & A & D
        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;
        // Checks if player pressed SPACE
        inputAction.Player.Jump.performed += cntxt => Jump();
        // Checks if player pressed LEFT MOUSE
        inputAction.Player.Shoot.performed += cntxt => Shoot();
        // Checks if player has moved or stoped moving MOUSE POINTER
        inputAction.Player.Look.performed += cntxt => rotate = cntxt.ReadValue<Vector2>();
        inputAction.Player.Look.canceled += cntxt => rotate = Vector2.zero;

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponentInParent<Collider>().bounds.extents.y;
    }
    // checks if player is on the ground then adds upwards velocity to player is jump is pressed
    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false; 
        }
    }
    // shoot function spawns and projectile and adds force too it
    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    public void updatePlayerHealth(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }


    // Update is called once per frame
    void Update()
    {
        // for moving forward & backwards relative to character
       transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        // for moving left & right relative to character
       transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);
        // rotates player left and right depending on mouse input from unity input system
       transform.Rotate(Vector3.up * rotate.x * Time.deltaTime * rotateSpeed, Space.Self);


       isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
        // (distanceToGround - 1.5f)
    }



}
