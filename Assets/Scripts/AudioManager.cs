using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider slider;

    float initialValue;
    
    // Start is called before the first frame update
    void Start()
    {
        initialValue = PlayerPrefs.GetFloat("MasterVolume");
        slider.value = initialValue;
    }

    
    void Update()
    {
        if(initialValue != slider.value)
        {
            PlayerPrefs.SetFloat("MasterVolume" , slider.value);
            initialValue = slider.value;
        }
    }
}
