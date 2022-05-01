using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();
            player.collectiblesGathered++;
            SoundManager.PlaySound(SoundManager.Sound.Pickup);
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (CrossSceneInfo.levels[SceneManager.GetActiveScene().buildIndex - 4].collected)
        {
            gameObject.SetActive(false);
        }
    }
}
