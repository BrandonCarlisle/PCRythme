using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public static MenuAudio instance = null;

    void Awake()
    {
        PersistCheck();
    }

    public void RemoveBackgroundAudio()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = 0;
    }

    public void StartBackgroundAudio()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = .2f;
    }

    public void PlaySound(AudioClip sound)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();     
        audio.PlayOneShot(sound, 2f);
    }

    void PersistCheck()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
