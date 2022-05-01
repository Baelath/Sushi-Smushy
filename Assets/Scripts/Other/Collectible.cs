using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();
            player.collectiblesGathered++;
            SoundManager.PlaySound(SoundManager.Sound.CollectiblePickup);
            gameObject.SetActive(false);
        }

    }
}
