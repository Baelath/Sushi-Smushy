using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInfo
{
    public static float oneShotVolume
    {
        get;
        set;
    } = 1f;

    public static float musicVolume
    {
        get;
        set;
    } = 1f;

    public static bool showContinueButton = false;

    public struct LevelState 
    {
        public int index;
        public bool unlocked;
        public bool collected;
        public int collectiblesMax;
    }

    public static LevelState[] levels;

    public static void Reset()
    {
        levels = new LevelState[5];

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].index = i;
            levels[i].unlocked = false;
            levels[i].collected = false;
            
            //get max collectibles per level and pass in later...
        }
    }
}