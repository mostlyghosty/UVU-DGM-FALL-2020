using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
     public float horizontalInput;
    public float forwardInput;

    public AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || forwardInput != 0)
        {
            if(!GetComponent<AudioSource>().isPlaying)
            {
            GetComponent<AudioSource>().Play();
            }
        }

        else
        {
             GetComponent<AudioSource>().Stop();
        }
    }
}
