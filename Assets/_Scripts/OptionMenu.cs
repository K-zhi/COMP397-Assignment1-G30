using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", 0.0f);
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
    }
}
