using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBounds = 30f;
    private float lowerBounds = -15f;
    
    //initializes the scale of time
    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {   

        //destroy any object entering the topbounds
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }

        //destroy any object entering the lowerbounds
        else if(transform.position.z < lowerBounds)
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
}
