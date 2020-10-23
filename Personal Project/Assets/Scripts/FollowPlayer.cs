using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     //sets target for camera to follow
    public GameObject player;

    //defines offset of camera
    public Vector3 offset = new Vector3(-20, 5, 0);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the player moves in a way that moves the camera out of bounds, put it back in bounds
        if (player.transform.position.x < -25)
        {
           transform.position = new Vector3(-45, (player.transform.position.y + 5), player.transform.position.z);
        }

        //if the camera is inbounds follows the player at a set distance
        else
        {
            transform.position = player.transform.position + offset;
        }
        

    }
}
