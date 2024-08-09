using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacles;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TimeBetweenSpawn;
    private float SpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime) {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    void Spawn() { 
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);

        Instantiate(Obstacles, transform.position + new Vector3(X,Y,0), transform.rotation);
    }
}
