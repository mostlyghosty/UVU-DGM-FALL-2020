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

    public float targetAngle;

    public float diffAngle;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //sets player rotation and puts it in terms of 180 degrees
        playerRotation = transform.rotation.eulerAngles.y;

        //calls horizontal and forward input from button press
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // If a direction button is pressed (if either input is not 0)
        if (forwardInput != 0 || horizontalInput != 0)
        {
            //find the target angle based on horizontalInput and ForwardInput and convert from radians to degrees (atan2 is in (y,x))
            targetAngle = Mathf.Atan2(-forwardInput, horizontalInput) * 180 / Mathf.PI + 180;

            //takes the Difference between the target angle and the player rotation with mod 360 (makes sure the answer is always between 0 & 360 (and not negative), takes full revolutions out)
            diffAngle = Mathf.Min((targetAngle - playerRotation + 360) % 360, (playerRotation - targetAngle + 360) % 360);


            //If Target angle and Player rotation are different rotate until they are close
            if (diffAngle > 10)
            {
               if (((targetAngle - playerRotation + 360) % 360) < ((playerRotation - targetAngle +360) % 360))
               {
                   transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
               }

               else 
               {
                   transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
               }
            }

            // else go forward
            else 
            {
                //Make rotation of character exact
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);

                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

        }
        
        // Starts and stops walking animation based on input
        if(horizontalInput != 0 || forwardInput != 0)
        {
            GetComponent<Animator>().Play("Move");
        }

        else
        {
            GetComponent<Animator>().Play("Idle");
        }
    
    }
}
