using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    //detects collision between ball and dog and destroys only the ball
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
