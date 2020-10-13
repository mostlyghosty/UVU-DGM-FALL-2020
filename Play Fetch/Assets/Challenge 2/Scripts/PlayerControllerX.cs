using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float time;
    private float timer;
    
    void Start()
    {
        //initializes variables
        time = 0.25f;
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the timer based on time not frames and counts down
        timer -= Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(timer < 0)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                //resets timer
                timer = time;
            }
        }
    }
}
