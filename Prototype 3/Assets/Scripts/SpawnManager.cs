using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    
    private float startDelay = 1;

    private float repeatInterval = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //repeats spawn obstacles at a set variable
      InvokeRepeating("SpawnObstacles", startDelay, repeatInterval);
    }

    // creates an instance of your obstacle
    void SpawnObstacles()
    {
      if(playerControllerScript.gameOver == false)
      {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
      }
    }
}   
