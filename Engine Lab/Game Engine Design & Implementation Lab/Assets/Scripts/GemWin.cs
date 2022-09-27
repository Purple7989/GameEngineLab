using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemWin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("YOU WIN!!!");
            Debug.Log("YOUR SCORE WAS");
            Debug.Log(ScoreManager.instance.score);
        }
    }
}
