using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coin collectio script using singleton
public class Coin : MonoBehaviour
{
    // collision function checks if it collided with player and tells scoremanager to add score 
    // before destroying its self
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);
        }
    }
}
