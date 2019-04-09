using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PCRhythm;

public class ScoreManager : MonoBehaviour
{
    public Text txtScore;
    public Text txtDance;
    Animator anim;
    private int countSuccess = 0;
    private int score;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        score = 0;
        txtScore.text = "Score: " + score.ToString();
        LevelSelect.levelScore = score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int amt)
    {
        if(amt<0)
        {
            anim.SetInteger("count",0);
            countSuccess = 0;
            txtDance.text = "Whoops ._.";
        }
        else if(countSuccess==5)
        {
            anim.SetInteger("count", 1);
            countSuccess++;
            txtDance.text = "Apprentice!";
        }
        else if(countSuccess==15)
        {
            anim.SetInteger("count", 2);
            Debug.Log("state2");
            countSuccess++;
            txtDance.text = "Experienced!";
        }
        else if (countSuccess == 30)
        {
            anim.SetInteger("count", 3);
            txtDance.text = "MLG!";
        }
        else if(countSuccess==50)
        {
            anim.SetInteger("count", 4);
            txtDance.text = "MASTER XD";
        }
        else
        {
            countSuccess++;
            Debug.Log(countSuccess);
        }

        score += amt;
        txtScore.text = "Score: " + score.ToString();
        LevelSelect.levelScore = score;
    }


}
