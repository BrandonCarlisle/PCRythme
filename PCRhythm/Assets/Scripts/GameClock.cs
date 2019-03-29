using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    public float GameTimer;

    public Text txtDebugTimer;
    public bool debugTimerActive = false;
    public float debugTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer += Time.deltaTime;

        if (debugTimerActive && txtDebugTimer != null)
        {
            debugTimer += Time.deltaTime;
            txtDebugTimer.text = debugTimer.ToString("0.00");
        }        
    }

    public void DisableDebugTimer()
    {
        debugTimer = 0f;
        debugTimerActive = false;
        if (txtDebugTimer != null)
            txtDebugTimer.text = "";
    }

    public void ActivateDebugTimer()
    {
        debugTimerActive = true;
    }
}
