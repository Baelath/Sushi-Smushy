using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            //Debug.Log(e.eventTick);
        };
    }
}