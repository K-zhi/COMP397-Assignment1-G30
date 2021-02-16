using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public InputField horizontalInput;
    public InputField verticalInput;
    public InputField jumpInput;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", 0.0f);
        horizontalInput.text = "A";
        verticalInput.text = "D";
        jumpInput.text = "Space";
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
    }


}
