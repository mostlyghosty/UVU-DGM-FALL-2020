using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //input detection
    public float horizontalInput;
    public float forwardInput;

    //Recieves info from inventory
    public bool inventoryOpen = false;

    // Update is called once per frame
    void Update()
    { 
        
        //Initializes input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //if input is detected and the inventory is not open
        if ((horizontalInput != 0 || forwardInput != 0) && !inventoryOpen)
        {
            //and the audiosource is not already playing start the footsteps
            if(!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            } 
        
        }

        //otherwise stop the footsteps (even if inventory is open)
        else if ((horizontalInput == 0 && forwardInput == 0) || inventoryOpen)
        {
            GetComponent<AudioSource>().Stop();
        }
        
        
    }
}
