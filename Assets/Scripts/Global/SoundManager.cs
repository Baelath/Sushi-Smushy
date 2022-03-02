using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{

    // todo: Add all sound triggers...
    public enum Sound
    {
        PlayerAttack1,
        PlayerAttack2,
        PlayerAttack3,
        PlayerDamaged,
        PlayerJump,
        PlayerDeath,
        ButtonClicked,
        ButtonHovered,
        Level1,
        Level2,
        Level3,
        LevelChange,
        CraftItem,
        EquipItem,
        PickupItem,
        DrinkPotion,
        ThrowPotion,
        EnemyDeath,
        Level1b,
        Level2b,
        Level3b,
        MainMenu
    }

    private static Dictionary<Sound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    private static GameObject musicGameObject;
    private static AudioSource musicAudioSource;
    private static float musicVolume;
    private static float oneShotVolume;


    // dont forget to call this somewhere in an Awake()...
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerJump] = 0f;
    }

    // 3D sound (falloff etc)...
    public static void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;
            audioSource.volume = oneShotVolume;
            audioSource.Play();

            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    // 2D sound...
    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One Shot Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.volume = CrossSceneInfo.oneShotVolume;
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    public static void PlayBackgroundMusic(Sound sound)
    {
        if (musicGameObject == null)
        {
            musicGameObject = new GameObject("Background Music");
            musicAudioSource = musicGameObject.AddComponent<AudioSource>();
        }
        musicAudioSource.volume = CrossSceneInfo.musicVolume;
        musicAudioSource.loop = true;
        musicAudioSource.clip = GetAudioClip(sound);
        musicAudioSource.Play();
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.PlayerJump:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = 0.05f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return true;
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundClip soundClip in GameAssets.instance.soundClipArray)
        {
            if (soundClip.sound == sound)
                return soundClip.audioClip;
        }
        //Debug.Log("Sound " + sound + " not found.");
        return null;
    }

    public static void AdjustMusicVolume(float volume)
    {
        musicVolume = volume;
        //Debug.Log("[SOUND MANAGER] Music Volume changed to " + volume);

        if (musicGameObject != null)
            musicAudioSource.volume = musicVolume;
    }

    public static void AdjustOneShotVolume(float volume)
    {
        oneShotVolume = volume;

        if (oneShotGameObject != null)
            oneShotAudioSource.volume = musicVolume;
    }
}