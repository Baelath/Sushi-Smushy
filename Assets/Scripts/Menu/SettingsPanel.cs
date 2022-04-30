using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Slider backgroundVol;
    [SerializeField]
    private Slider SFXVol;

    private void Start()
    {
        transform.localScale = Vector2.zero;

        backgroundVol.value = CrossSceneInfo.musicVolume;
        SFXVol.value = CrossSceneInfo.oneShotVolume;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.5f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.25f).setEaseInBack();
    }

    public void BackgroundVolume()
    {
        CrossSceneInfo.musicVolume = backgroundVol.value;
        SoundManager.AdjustMusicVolume(backgroundVol.value);
    }

    public void SFXVolume()
    {
        CrossSceneInfo.oneShotVolume = SFXVol.value;
        SoundManager.AdjustOneShotVolume(SFXVol.value);
    }
}
