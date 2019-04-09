using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuClickSoundEffect : MonoBehaviour
{
    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        button.onClick.AddListener(() => MenuAudio.instance.PlaySound(sound));
    }

    // Update is called once per frame

}
