using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    private float distance;
    private Vector3 startPosition;
    private float distToStart;
    private Rigidbody rb;
    public int enemyHealth = 3;

    //singleton for enemy
    public static EnemyBehavior instance;

    // Start is called before the first frame update
    void Awake()
    {
        // make sure their are no other enemy singletons 
        if (!instance)
        {
            instance = this;
        }
        // grab the starting position of the enemy & rigidbody component 
        startPosition = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // this state is used when the player is within a certain distance of the player
    // moves towards the player
    private void Engaged()
    {
        Vector3 movePos = PlayerController.instance.transform.position;
        transform.LookAt(movePos);
        transform.Translate(Vector3.forward * Time.deltaTime * 2.5f, Space.Self);
    }
    // this state is when the player is too far from the enemy and the enemy is out
    // of its starting position
    private void returnToPositon()
    {
        if (distToStart >= 2.0f)
        {
            transform.LookAt(startPosition);
            transform.Translate(Vector3.forward * Time.deltaTime * 2.5f, Space.Self);
        }
    }
    // can be called by other files to change the health of the enemy
    public void changeHealth(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            PlayerController.instance.updatePlayerHealth(1);
        }
    }


    //Gets distance to player and starting position then activates each state depending on distance to player
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(PlayerController.instance.transform.position, gameObject.transform.position);
        distToStart = Vector3.Distance(startPosition, gameObject.transform.position);

        if (distance <= 15.0f)
        {
            Engaged();
        }
        else
        {
            returnToPositon();
        }
    }
}
