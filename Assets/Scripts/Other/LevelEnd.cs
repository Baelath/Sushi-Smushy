using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private int index;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();
            CrossSceneInfo.levels[index].unlocked = true;
            CrossSceneInfo.CheckCollectible(player.collectiblesGathered, index - 1);

            SceneManager.LoadScene(4);
        }
    }
}
