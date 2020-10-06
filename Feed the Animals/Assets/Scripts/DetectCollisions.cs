using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    //detects collisions between colliders
    void OnTriggerEnter(Collider other)
    {
        //destroys th object this script is on
        Destroy(gameObject);

        //destroys the colliding object
        Destroy(other.gameObject);
    }
}
