using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseEvents : MonoBehaviour
{
    //Raycast
    private GraphicRaycaster slotRaycast;
    private PointerEventData pointerData;
    private EventSystem gameEventSystem; 

    //item the ray hits
    public string usedItem;

    public string hover;

    //send info to inventory
    public Inventory sendToInventory;

    public DetectCollisions sendToDetectCollisions;

    public int tap = 0;

    // Start is called before the first frame update
    void Start()
    {
        //initializes the raycast and the eventsystem
        slotRaycast = GetComponent<GraphicRaycaster>();
        gameEventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tap++;

            StartCoroutine(ClearTaps());

            //checks for a double click
            if(tap > 1)
            {
                //resets the double cilck
                tap = 0;

                //Initializes pointer Data and bases it on mouse position
                pointerData = new PointerEventData(gameEventSystem);
                pointerData.position = Input.mousePosition;

                //creates a list to store the results of what the ray hit (will always be tied to the slot the script is attached to)
                List<RaycastResult> results = new List<RaycastResult>();

                //Shoots the ray and sends what it hit to results
                slotRaycast.Raycast(pointerData, results);

                //sends results to use Item
                foreach (RaycastResult result in results)
                {
                    usedItem = result.gameObject.GetComponent<Text>().text;
                }

                //Closes the inventory when an Item has been used and sends info to detect colisions
                if (usedItem != null && usedItem != "")
                {
                    GameObject inventory = GameObject.Find("Inventory");
                    Time.timeScale = 1;
                    inventory.SetActive(false);
                    sendToInventory.inventoryEnabled = false;

                    sendToDetectCollisions.clickEvent = true;
                    sendToDetectCollisions.usedItem = usedItem;
                    
                    usedItem = null;
                }
            }
        }
    }

    //Clears tap data if double click is not fast enough
    IEnumerator ClearTaps()
    {
        yield return new WaitForSecondsRealtime(.5f);
        tap = 0;
    }

}
