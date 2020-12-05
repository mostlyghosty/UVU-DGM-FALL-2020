using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //rigid body of the prefab
    private Rigidbody targetRb;

    //floats to control the movement and spawn position of the prefab
    private float minSpeed = 12, 
                  maxSpeed = 16,
                  maxTorque = 10,
                  xRange = 4,
                  ySpawnPos = -6;

    //gets the game manager script
    private GameManager gameManager;

    //keeps track of the point value of the prefab
    public int pointValue;

    //particle system
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        //initializes the physics
        targetRb = gameObject.GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();

        //initializes the game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    //random functions to help initialize the physics
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    //when the mouse is clicked
    void OnMouseDown()
    {
        //if the game is active
        if(gameManager.isGameActive)
        {
            //destroy the item clicked
            Destroy(gameObject);
            //set off the particles
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            //update the player's score
            gameManager.UpdateScore(pointValue);
        }

        //if the object is bad
        if(gameObject.CompareTag("Bad"))
        {
            //trigger game over
            gameManager.GameOver();
        }
    }

    //prevents prefabs from colliding with eachother
    void OnTriggerEnter(Collider Other)
    {
        Destroy(gameObject);
    }
}
