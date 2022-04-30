using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        GetComponent<CircleCollider2D>().radius = radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            anim.SetBool("inRange", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("inRange", false);
        }
    }
}
