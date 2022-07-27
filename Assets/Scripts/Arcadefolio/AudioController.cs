using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private AudioSource mainAudio;
    private float volume = 1;
    public Slider volumeSlider;
    public AudioSource extraAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mainAudio.volume = volume / 2;
        if (extraAudioSource != null)
        {
            extraAudioSource.volume = volume;
        }
    }

    public void ChangeVolume(float volume)
    {
        this.volume = volume;
    }

    public void Mute()
    {
        volume = 0;
        volumeSlider.value = 0;
    }

    public void ValueChangeCheck()
    {
        ChangeVolume(volumeSlider.value);
    }

}
