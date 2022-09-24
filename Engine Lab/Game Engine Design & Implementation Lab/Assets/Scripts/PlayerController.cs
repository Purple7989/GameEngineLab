using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponentInParent<Collider>().bounds.extents.y;
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false; 
        }
    }

    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // for moving forward & backwards relative to character
       transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        // for moving left & right relative to character
       transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
        // (distanceToGround - 1.5f)
    }



}
