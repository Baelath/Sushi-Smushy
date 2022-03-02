using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider oneShotVolumeSlider;

    private void Awake()
    {
        //Debug.LogFormat("{0},{1}", CrossSceneInfo.oneShotVolume, CrossSceneInfo.musicVolume);
        //SoundManager.AdjustMusicVolume(musicVolumeSlider.value);
        //SoundManager.AdjustOneShotVolume(oneShotVolumeSlider.value);
        oneShotVolumeSlider.value = CrossSceneInfo.oneShotVolume;
        musicVolumeSlider.value = CrossSceneInfo.musicVolume;
        OneShotVolume();
        MusicVolume();

        musicVolumeSlider.onValueChanged.AddListener(delegate { MusicVolume(); });
        oneShotVolumeSlider.onValueChanged.AddListener(delegate { OneShotVolume(); });
    }

    public void OneShotVolume()
    {
        SoundManager.AdjustOneShotVolume(oneShotVolumeSlider.value);
        CrossSceneInfo.oneShotVolume = oneShotVolumeSlider.value;
    }

    public void MusicVolume()
    {
        SoundManager.AdjustMusicVolume(musicVolumeSlider.value);
        CrossSceneInfo.musicVolume = musicVolumeSlider.value;
    }
}