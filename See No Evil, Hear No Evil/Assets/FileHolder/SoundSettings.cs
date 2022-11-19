using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        //Name of the exposed parameter for audiomixer, I changed mine to volume.
        audioMixer.SetFloat("volume", volume);
    }
}
