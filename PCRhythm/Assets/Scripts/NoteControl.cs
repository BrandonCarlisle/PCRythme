using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour
{
    public float speed;
    public float noteDelay;
    public ScoreManager scoreManager;
    public GameClock gameClock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (noteDelay <= gameClock.GameTimer)
        {
            transform.position += transform.right * Time.deltaTime * speed;

            if (transform.position.x >= 8.8)
                Missed();
        }
    }

    public void Hit()
    {
        //can get notetype from here if needed for score.
        if (scoreManager != null)
            scoreManager.AddToScore(100);

        Destroy(gameObject);
    }


    void Missed()
    {
        if (scoreManager != null)
            scoreManager.AddToScore(-100);

        Destroy(gameObject);
    }
}
