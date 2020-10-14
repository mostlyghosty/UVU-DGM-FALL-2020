using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    
    private float startDelay;

    private float repeatInterval;

    // Start is called before the first frame update
    void Start()
    {
        //repeats spawn obstacles at a set variable
      InvokeRepeating("SpawnObstacles", startDelay, repeatInterval);
    }

    // creates an instance of your obstacle
    void SpawnObstacles()
    {
         Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}   
