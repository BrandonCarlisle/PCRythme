using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using PCRhythm;

public class DizzyOnClick : MonoBehaviour
{
    public void LoadScene()
    {
        LevelSelect.level = 2;
        LevelSelect.levelScore = 0;
        SceneManager.LoadScene(2);
    }
}
