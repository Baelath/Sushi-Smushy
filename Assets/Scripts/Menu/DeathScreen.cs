using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private bool dead = false;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void ShowDeathScreen()
    {
        LeanTween.value(gameObject, setSpriteAlpha, 0f, 1f, 0.2f);
        dead = true;
    }

    private void Update()
    {
        if (dead)
            StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void setSpriteAlpha(float value)
    {
        image.color = new Color(1f, 1f, 1f, value);
    }
}
