using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //move object forwards on the z axis
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
