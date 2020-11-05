using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        //Gets the Horizontal input for camera rotation around the z-axis
        float horizontalInput = Input.GetAxis("Horizontal");

        //rotates camera around the z-axis
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
