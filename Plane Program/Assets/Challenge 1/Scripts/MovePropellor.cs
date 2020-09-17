using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePropellor : MonoBehaviour

{
    //Set float for speed of propellor rotation
    private float speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate propellor
        transform.Rotate(Vector3.forward * speed);
    }
}
