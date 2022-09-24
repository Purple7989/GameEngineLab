using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coin collectio script using singleton
public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);
        }
    }
}
