using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadClip(string clip, float startAt = 0f)
    {
        audio = gameObject.GetComponent<AudioSource>();
        AudioClip clip1 = (AudioClip)Resources.Load("SongsAudio/" + clip);
        audio.clip = clip1;
        audio.time = startAt;
        audio.Play();
    }

    public IEnumerator LoadClipDelay(string clip, float seconds, float startAt = 0f)
    {
        audio = gameObject.GetComponent<AudioSource>();
        AudioClip clip1 = (AudioClip)Resources.Load("SongsAudio/" + clip);
        audio.clip = clip1;

        if (startAt > 0)
            audio.time = startAt;

        yield return new WaitForSeconds(seconds);
        audio.Play();
    }

    public void StopClip()
    {
        audio.Stop();
    }
}
