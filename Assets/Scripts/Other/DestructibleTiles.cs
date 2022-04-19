using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player on destructible tile!");

            Vector3 hitPos = Vector3.zero;

            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x;
                hitPos.y = hit.point.y - 0.01f;

                tilemap.SetTile(tilemap.WorldToCell(hitPos), null);
            }
        }
    }
}
