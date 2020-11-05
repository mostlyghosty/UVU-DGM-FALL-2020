using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    public GameObject clickedOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If Left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Checks to see if the inventory is up
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            RaycastHit hit;

            //assigns a ray using the position of the camera and the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //If the ray goes out
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                 //and hits something
                if (hit.transform != null)
                {
                    //clicked on is initialized with the game oject that is clicked on
                    clickedOn = hit.transform.gameObject;
                    Debug.Log("You Clicked on: " + clickedOn);
                }
             }  
        }
    }
}
