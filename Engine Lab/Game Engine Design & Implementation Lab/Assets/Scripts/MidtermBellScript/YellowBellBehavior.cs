using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBellBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks the collider tag and instance as to wether it should use the other bell's ability
        if (collision.collider.tag == "Player" && BellManager.instance.shouldSwap == false)
        {
            PlayerController.instance.playerHealth += 3;
            Debug.Log("new Player Helath is " + PlayerController.instance.playerHealth);
            BellManager.instance.SwapBells(1);
        }
        //After Swap Ability
        else if(collision.collider.tag == "Player" && BellManager.instance.shouldSwap == true)
        {
            PlayerController.instance.jumpheight = 10;
            Debug.Log("Jump Height Changed");
        }
    }
}
