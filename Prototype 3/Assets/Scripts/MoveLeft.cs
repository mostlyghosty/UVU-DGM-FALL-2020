using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //speed at which object moves
    public float speed = 10f;

    //place for Player Controller script
    private PlayerController playerControllerScript;

    //
    private float leftBound = -15f; 

    // Start is called before the first frame update
    void Start()
    {
        //gets the player controller script from the player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //while the game is running move the objects
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //once te object is out of bounds destroy it
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
