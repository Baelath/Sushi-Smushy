using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int ticksToBreakMax;
    private int ticksToBreak;

    [SerializeField]
    private int ticksToRespawnMax;
    private int ticksToRespawn;

    private SpriteRenderer sr;
    private Animator anim;

    private bool isBreaking;
    private bool isRespawning;

    private void Start()
    {
        ticksToBreak = ticksToBreakMax;
        ticksToRespawn = ticksToRespawnMax;

        //anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;

        TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            BreakTile();
            ResetTile();
        };

        isBreaking = false;
        isRespawning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBreaking = true;
        }
    }

    private void ResetTile()
    {
        if (isRespawning)
        {
            ticksToRespawn--;
            //Debug.Log(ticksToRespawn);
        }

        if (ticksToRespawn <= 0)
        {
            //Play respawn animation

            ticksToBreak = ticksToBreakMax;
            ticksToRespawn = ticksToRespawnMax;

            isRespawning = false;
            isBreaking = false;

            gameObject.SetActive(true);
        }
    }

    private void BreakTile()
    {
        if (isBreaking)
        {
            ticksToBreak--;
            //Debug.Log(ticksToBreak);
        }

        if (ticksToBreak <= 0)
        {
            //Play Break animation

            isRespawning = true;
            isBreaking = false;

            gameObject.SetActive(false);
        }
    }
}
