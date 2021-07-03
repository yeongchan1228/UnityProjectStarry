using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    float volume;
    public AudioSource audioSource;
    public Slider volslider;
    void Start()
    {
        volslider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        if(volslider != null)
            volslider.onValueChanged.AddListener(SetAudioVol);
    }

    public void GetSlider()
    {
        volslider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        volslider.onValueChanged.AddListener(SetAudioVol);        
    }

    public void SetAudioVol(float vol)
    {
        audioSource.volume = vol;
    }
}
