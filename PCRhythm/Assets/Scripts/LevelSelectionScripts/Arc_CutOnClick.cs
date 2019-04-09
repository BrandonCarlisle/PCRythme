using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using PCRhythm;

public class Arc_CutOnClick : MonoBehaviour
{
    public void LoadScene()
    {
        LevelSelect.level = 1;
        LevelSelect.levelScore = 0;
        SceneManager.LoadScene(2);
    }
}
