using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    private VideoPlayer player;

    private void Start()
    {
        SoundManager.StopBackgroundMusic();

        player = GetComponent<VideoPlayer>();
        player.SetDirectAudioVolume(0, CrossSceneInfo.musicVolume);
        Debug.Log(CrossSceneInfo.musicVolume);

        player.loopPointReached += StartGame;

        CrossSceneInfo.levels[0].unlocked = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void StartGame(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void OnDestroy()
    {
        player.loopPointReached -= StartGame;
;    }
}
