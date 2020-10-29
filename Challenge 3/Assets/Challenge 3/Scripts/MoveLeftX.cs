using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    //speed at which the object moves
    public float speed;

    //creates a variable to hold the Player controller script
    private PlayerControllerX playerControllerScript;

    //creates a variable for the outmost left bound restraint
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        //calls player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
