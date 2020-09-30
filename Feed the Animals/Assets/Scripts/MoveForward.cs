using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;

    // Update is called once per frame
    void Update()
    {
        //move object forwards on the z access
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
