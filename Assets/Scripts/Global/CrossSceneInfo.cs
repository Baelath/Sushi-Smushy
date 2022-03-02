using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInfo
{
    public static int sceneToLoad
    {
        get;
        set;
    }

    public static string fileToLoad
    {
        get;
        set;
    }

    public static bool load
    {
        get;
        set;
    }

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

    // remember to set to level start on scene change...
    public static Vector3 lastSavedPos;
}