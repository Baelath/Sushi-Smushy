using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

        TimeTickSystem.OnTick += BreakTile;
        TimeTickSystem.OnTick += ResetTile;

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

    private void ResetTile(object sender, TimeTickSystem.OnTickEventArgs e)
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

    private void BreakTile(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (isBreaking)
        {
            ticksToBreak--;
            //Debug.Log(ticksToBreak);
        }

        if (ticksToBreak <= 0)
        {
            if (!isRespawning && isBreaking)
                SoundManager.PlaySound(SoundManager.Sound.TileBreak);

            isRespawning = true;
            isBreaking = false;

            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        TimeTickSystem.OnTick -= BreakTile;
        TimeTickSystem.OnTick -= ResetTile;
    }
}
