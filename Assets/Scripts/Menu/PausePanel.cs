using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private bool open = false;

    [SerializeField]
    private Slider backgroundVol;
    [SerializeField]
    private Slider SFXVol;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;

        backgroundVol.value = CrossSceneInfo.musicVolume;
        SFXVol.value = CrossSceneInfo.oneShotVolume;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.2f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.2f);
    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene(3);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            
            if (open)
                Open();
            else
                Close();
        }
    }
}
