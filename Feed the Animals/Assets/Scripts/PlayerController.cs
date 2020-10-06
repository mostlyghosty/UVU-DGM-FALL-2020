using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float moveSpeed = 20f;

    private float xRange = 18;

    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        //Gets the horizontal input
        horizontalInput = Input.GetAxis("Horizontal"); 

        //Moves player back and forth based on horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);

        //If player leaves play area reset position back in play
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //Creates instance of a projectile when space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
