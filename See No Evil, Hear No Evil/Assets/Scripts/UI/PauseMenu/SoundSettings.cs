using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixerGroup audioMixerGrp;

    public void SetVolume(float volume)
    {
        //Name of the exposed parameter for audiomixer, I changed mine to volume.
        audioMixerGrp.audioMixer.SetFloat("Master", volume);
    }
}
