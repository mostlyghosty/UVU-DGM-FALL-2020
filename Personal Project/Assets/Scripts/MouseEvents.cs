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

    //send info to inventory
    public Inventory sendToInventory;

    public DetectCollisions sendToDetectCollisions;

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
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Initializes pointer Datat and bases it on mouse position
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

            //Closes the inventory when an Item has been used and sends the item name dialogue
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
