using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    public GameObject player;

    // On collision enter funtion that detects if it hits the player and changes it's health before
    // destroying the projectile
    private void OnCollisionEnter(Collision collision)
    {
        // chech if it hit the enemy
        if(collision.collider.tag == "Enemy")
        {
            // change the health of he enemy it collided with
            collision.collider.GetComponent<EnemyBehavior>().changeHealth(1);
        }

        // destroy the projectile after it hits something
        Destroy(gameObject);
    }
    // during update it gets the distance from the player to the projectile and destroys the projectile
    // if it is too far from the player
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance > 80.0f)
        {
            Destroy(gameObject);
        }

    }
}
