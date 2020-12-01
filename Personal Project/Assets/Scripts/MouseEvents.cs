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

    //holds the item slot game object that was clicked on
    private GameObject itemSlot;
    
    //scripts
    public Inventory sendToInventory;
    public ItemManagement sendToItemManagement;
    public Footsteps sendToFootsteps;


    //number of clicks
    public int tap = 0;

    //whether or not an item was trying to be crafted
    public bool crafted = false;

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
            tap++;

            StartCoroutine(ClearTaps());

            //checks for a double click
            if(tap > 1)
            {
                //clears mouse clicks if not used quick enough
                StartCoroutine(ClearTaps());

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

                    //and initializes item slot
                    itemSlot = result.gameObject;

                }

                //Closes the inventory when an Item has been used and sends info to item Management
                if (usedItem != null && usedItem != "" && !crafted)
                {
                    //sneds info about the slot strage gem is on so that Item management can remove it from the inventory
                    if (usedItem == "Strange Gem")
                    {
                        sendToItemManagement.strangeGem = itemSlot;
                    }

                    //closes inventory
                    GameObject inventory = GameObject.Find("Inventory");
                    Time.timeScale = 1;
                    inventory.SetActive(false);
                    sendToInventory.inventoryEnabled = false;

                    //tells footsteps that the inventory is not open
                    sendToFootsteps.inventoryOpen = false;

                    sendToItemManagement.clickEvent = true;
                    sendToItemManagement.usedItem = usedItem;
                    
                    //clears the used Item to close the loop
                    usedItem = null;
                }

                //if something is trying to be crafted DO NOT close the inventory
                else if (crafted)
                {
                    crafted = false;
                }

            }

            //if taps go above 2 clear them automatically (keeps extra clicks from being stored)
            if (tap > 2)
            {
                tap = 0;
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
