using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PCRhythm;

public class GameOverControllerScript : MonoBehaviour
{
    public Text txtScore;
    public Text txtRank;


    // Start is called before the first frame update
    void Start()
    {
        MenuAudio.instance.StartBackgroundAudio();
        txtScore.text = "Score: " + LevelSelect.levelScore;
        txtRank.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
