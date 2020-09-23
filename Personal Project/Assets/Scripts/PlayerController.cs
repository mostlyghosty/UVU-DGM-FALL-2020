using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public int speed;
    public float turnSpeed;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed * horizontalInput);
        
        if(horizontalInput > 0){
            GetComponent<Animation>().Play("Move");
        }

        else if(forwardInput > 0){
            GetComponent<Animation>().Play("Move");
        }

        else{

        }
    }
}
