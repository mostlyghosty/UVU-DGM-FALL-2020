using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    //creates variable array to hold object prefabs
    public GameObject[] objectPrefabs;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //starts an instance of an object
        Invoke("SpawnObjects", 0);

        //calls the player controller script and puts it in a variable
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object an then invoke it recursively
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
            Invoke("SpawnObjects", Random.Range(1, 3));
        }

    }
}
