using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed of the enemy
    public float speed;

    //The Enemies rigidbody
    private Rigidbody enemyRb;

    //the player
    private GameObject player;

    //the number of enemies
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //initializes the enemy rigidbody and the player game object
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //the direction in which the enemy needs to travel
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //moving the enemy towards the player
        enemyRb.AddForce(lookDirection * speed);

        //if the enemy falls off the platform destroy it
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
