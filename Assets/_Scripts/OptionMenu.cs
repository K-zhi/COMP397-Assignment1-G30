using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", -30.0f);
        slider.value = -30.0f;
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
        Debug.Log("chanegd volume:"+vol);
    }
}
