using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Button[] levels;
    [SerializeField]
    private GameObject[] soyBottles;

    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (CrossSceneInfo.levels[i].unlocked)
                levels[i].interactable = true;

            if (CrossSceneInfo.levels[i].collected)
                soyBottles[i].SetActive(true);
        }
    }

    public void LevelSelected(int index)
    {
        SoundManager.PlaySound(SoundManager.Sound.ButtonPress);
        SceneManager.LoadScene(index);
    }
}
