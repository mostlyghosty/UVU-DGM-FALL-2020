using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //The start position ofthe background
    private Vector3 startPos;

    //unit to hols size that the background needs to repeat
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //initializes startPos with the current position of the background
        startPos = transform.position;

        //initializes repeat width with the current size of the background box collider
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the position of the background is less than the starting position minus the repeat width
        //aka if the background has moved backwards half of it's length
        //move it back to it's start postition
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
