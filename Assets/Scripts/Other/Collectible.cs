using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Get collected...
            SoundManager.PlaySound(SoundManager.Sound.CollectiblePickup);
            gameObject.SetActive(false);
        }

    }
}
