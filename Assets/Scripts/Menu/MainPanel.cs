using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;

    private void Start()
    {
        if (CrossSceneInfo.showContinueButton)
            continueButton.gameObject.SetActive(true);

        //SoundManager.PlayBackgroundMusic(SoundManager.Sound.MainMenu);

        DontDestroyOnLoad(GameObject.Find("Background Music"));
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.25f).setEaseInBack();
    }

    public void Open()
    {
        transform.LeanScale(Vector3.one, 0.5f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        CrossSceneInfo.Reset();
        CrossSceneInfo.showContinueButton = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(3);
    }
}
