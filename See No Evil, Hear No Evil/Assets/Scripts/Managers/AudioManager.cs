using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject player;
    public Audio[] audioClips;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        foreach (Audio a in audioClips)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
            a.source.maxDistance = 8;
        }
    }

    private void Update()
    {
        foreach (Audio a in audioClips)
        {
            if (player.GetComponent<SenseModes>().visionMode == true)
            {
                a.source.volume = 0;
            }
            else
            {
                a.source.volume = a.volume;
            }
        }
    }

    public void Play(string name)
    {
        Audio a = Array.Find(audioClips, audio => audio.name == name);

        if (a == null)
        {
            Debug.Log("Not Found");
            return;
        }

        a.source.Play();
    }

    public void Stop(string name)
    {
        Audio a = Array.Find(audioClips, audio => audio.name == name);

        if (a == null)
        {
            Debug.Log("Not Found");
            return;
        }

        a.source.Stop();
    }
}
