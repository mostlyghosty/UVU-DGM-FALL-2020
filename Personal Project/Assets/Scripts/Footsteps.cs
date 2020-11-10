using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //input detection
    public float horizontalInput;
    public float forwardInput;

    //sfx
    public AudioSource footsteps;

    // Update is called once per frame
    void Update()
    {
        //Initializes input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //if input is detected
        if (horizontalInput != 0 || forwardInput != 0)
        {
            //and the audiosource is not already playing start the footsteps
            if(!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }

        //otherwise stop the footsteps
        else
        {
             GetComponent<AudioSource>().Stop();
        }
    }
}
