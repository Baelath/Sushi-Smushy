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
        player = GetComponent<VideoPlayer>();
        player.SetDirectAudioVolume(0, CrossSceneInfo.musicVolume);
        Debug.Log(CrossSceneInfo.musicVolume);

        player.loopPointReached += StartGame;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StartGame(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy()
    {
        player.loopPointReached -= StartGame;
;    }
}
