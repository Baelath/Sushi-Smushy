using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject dropletPrefab;

    [SerializeField]
    private int TicksPerDropletMax;

    private int ticksToSpawn;

    private void Start()
    {
        ticksToSpawn = TicksPerDropletMax;
        TimeTickSystem.OnTick += SpawnDroplet;
    }

    private void SpawnDroplet (object sender, TimeTickSystem.OnTickEventArgs e)
    {
        ticksToSpawn--;

        if (ticksToSpawn <= 0)
        {
            ticksToSpawn = TicksPerDropletMax;

            GameObject droplet = Instantiate(dropletPrefab) as GameObject;
            droplet.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.4f, 1f);
            droplet.GetComponent<WaterDroplet>().lifetime = TicksPerDropletMax * 0.19f;
        }
    }


    private void OnDestroy()
    {
        TimeTickSystem.OnTick -= SpawnDroplet;
    }
}
