using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public InputField leftInput;
    public InputField rightInput;
    public InputField forwardInput;
    public InputField backInput;
    public InputField jumpInput;
    public InputField pauseInput;
    public InputField inventoryInput;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", -30.0f);
        slider.value = -30.0f;
        leftInput.text = "A";
        rightInput.text = "D";
        forwardInput.text = "W";
        backInput.text = "S";
        jumpInput.text = "Space";
        inventoryInput.text = "I";
        pauseInput.text = "P";
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
    }


}
