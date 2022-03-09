using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] [Range(1f, 3f)] private float speed;

    private int currentWaypointIndex = 0;
    private bool waited = false;

    private void Start()
    {
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if (waited)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length)
                    currentWaypointIndex = 0;
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        waited = true;
    }
}
