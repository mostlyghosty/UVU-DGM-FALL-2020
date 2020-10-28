using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //creates a variable for the obstacle you wish to use
    public GameObject obstaclePrefab;

    //sets the position the obstacle should spawn from
    private Vector3 spawnPos = new Vector3 (25, 0, 0);
    
    //invoke repeating intervals
    private float startDelay = 1;
    private float repeatInterval = 2;

    //creates a variable to hold the player Controller Script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
      //calls the Player controller script from the player and stores it
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //repeats spawn obstacles at a set variable
      InvokeRepeating("SpawnObstacles", startDelay, repeatInterval);
    }

    // creates an instance of your obstacle
    void SpawnObstacles()
    {
      //as long as the game is not over create an instance of the obstacle
      if(playerControllerScript.gameOver == false)
      {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
      }
    }
}   
