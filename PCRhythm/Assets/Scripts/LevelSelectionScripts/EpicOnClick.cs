using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using PCRhythm;

public class EpicOnClick : MonoBehaviour
{
    public void LoadScene()
    {
        LevelSelect.level = 3;
        LevelSelect.levelScore = 0;
        SceneManager.LoadScene(2);
    }
}
