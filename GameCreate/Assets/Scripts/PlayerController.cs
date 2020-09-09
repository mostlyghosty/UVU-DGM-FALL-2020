using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 20; //integers are private by default you have to declare it as public

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forwards
        //transform.Translate(0, 0, 5); x is left and right, y is up and down, z is move forward or backwards in space
        // transform.Translate(Vector3.forward); a command to move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
