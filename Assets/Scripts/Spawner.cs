using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate;
    public GameObject hexagonPrefab;
    private float nexTimeToSpawn;
    

    void Update()
    {
        
        if (Time.time >= nexTimeToSpawn)
        {
            Instantiate(hexagonPrefab);
            nexTimeToSpawn = Time.time + spawnRate;
        }
    }

}
