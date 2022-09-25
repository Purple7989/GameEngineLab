using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // to allow other scripts to accsess use this (Singleton)
    public static ScoreManager instance;
    // The score we use
    public int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        // if instance != null;
        if(!instance)
        {
            instance = this;
        }
    }
    // public function for changing the score, other scripts can call this
    public void ChangeScore(int coinInput)
    {
        score += coinInput;
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
