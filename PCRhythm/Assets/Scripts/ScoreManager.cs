using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //manage score. extend this to track multiplier, failmeter etc.

    public Text txtScore;
    

    private int score;
    //private int multiplier;

    void Start()
    {    
        score = 0;
        txtScore.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddToScore(int amt)
    {
        score += amt;
        txtScore.text = "Score: " + score.ToString();
    }

    //public void Multiplier()
    //{

    //}
}
