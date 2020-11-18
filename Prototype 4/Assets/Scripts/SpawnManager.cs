using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //game objects for the powerup and enemy
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    //the range in which things can spawn
    private float spawnRange = 10;

    //the number of Enemies
    public int enemyCount;

    //the wave number
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {  
        //spawns the initial enemy and powerup
       SpawnEnemyWave(waveNumber);
       Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    void Update()
    {
        //finds how man enemies are in play
        enemyCount = FindObjectsOfType<Enemy>().Length; 

        // if there are no enemies
        if(enemyCount == 0)
        {
            //increment the wave number
            waveNumber ++;

            //spawn enemies depending on what the wave number is and spawn another powerup
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //random spawn position based on the spawn range
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        //sets the random position to a vector
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        //returns that vector 
        return randomPos;
        
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //if the number of enemies is less than the number of enemies to spawn, spawn another enemy and increment i, when i and enemies to spaw become equal stop spawning enemies
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
