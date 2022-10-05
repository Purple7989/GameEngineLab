using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellManager : MonoBehaviour
{
    // Singleton Pattern being implemented
    public static BellManager instance;

    public bool shouldSwap = false;
    public int numofSwaps = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapBells(int swapIncrease)
    {
        // after activating both bells the their functions will swap
        if(numofSwaps >= 2)
        {
            shouldSwap = true;
        }
        else
        {
            numofSwaps += swapIncrease;
            Debug.Log("numOfSwaps is " + numofSwaps);
        }
    }
}
