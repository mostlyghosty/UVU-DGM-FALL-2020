using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public int speed;
    public float turnSpeed;
    
    public float playerRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets player rotation and puts it in 180 degree terms
        playerRotation = transform.rotation.eulerAngles.y - 180;

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0)
        {
           if (Mathf.Abs(0 - playerRotation) > 10)
           {
              transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
           }

          else
          {
              transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
          }
        }

         else if (horizontalInput < 0)
         {
             if (Mathf.Abs(180 - playerRotation) > 10)
             {
                 transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
             }

             else 
             {
                 transform.Translate(Vector3.back * Time.deltaTime * speed * horizontalInput);
             }
         }

         else if (forwardInput > 0)
         {
             if (Mathf.Abs(-90 - playerRotation) > 10)
             {
                 transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
             }

             else 
             {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); 
             }
         }

         else if (forwardInput < 0)
         {
             if (Mathf.Abs(90 - playerRotation) > 10)
             {
                transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed); 
             }

             else 
             {
                 transform.Translate(Vector3.back * Time.deltaTime * speed * forwardInput);
             }
         }

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //transform.Rotate(Vector3.up* Time.deltaTime * turnSpeed * horizontalInput);
        
        // Starts and stops walking animation based on input
        if(horizontalInput != 0)
        {
            GetComponent<Animator>().Play("Move");
        }

        else if(forwardInput != 0)
        {
            GetComponent<Animator>().Play("Move");
        }

        else
        {
            GetComponent<Animator>().Play("Idle");
        }
    
    }
}
