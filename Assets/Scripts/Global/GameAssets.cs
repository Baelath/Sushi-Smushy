using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _instance;
        }
    }

    public SoundClip[] soundClipArray;

    public int GetRandomPercent()
    {
        return Random.Range(0, 101);
    }

    [System.Serializable]
    public class SoundClip
    {
        public AudioClip audioClip;
        public SoundManager.Sound sound;
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SoundManager.Initialize();

        SceneManager.sceneLoaded += OnSceneLoaded;

        TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            //Debug.Log(e.eventTick);
        };
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case 1:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.MainMenu);
                break;
            case 2:
                break;
            case 3:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.MainMenu);
                break;
            case 4:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level1);
                break;
            case 5:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level2);
                break;
            case 6:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level3);
                break;
            case 7:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level4);
                break;
            case 8:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level5);
                break;
            case 9:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level6);
                break;
            case 10:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level7);
                break;
            case 11:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level8);
                break;
            case 12:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level9);
                break;
            case 13:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.Level10);
                break;
            case 14:
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.MainMenu);
                break;

            default:
                break;
        }
    }
}