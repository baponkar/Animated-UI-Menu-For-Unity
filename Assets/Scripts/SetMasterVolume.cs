using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMasterVolume : MonoBehaviour
{
    float volume;
    float masterVolume;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        audio.volume = masterVolume;
    }

    
    void Update()
    {
        if(volume != masterVolume)
        {
            audio.volume = masterVolume;
        }
    }
}
