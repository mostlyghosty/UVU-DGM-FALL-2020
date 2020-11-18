using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    //Detects if the Inventory is enabled
    public bool inventoryEnabled = false;

    //the inventory game object
    public GameObject inventory;

    //recieves information from Item Mangager to fill these slots
    public Text[] slots;
    public Footsteps sendToFootsteps;

    void Awake()
    {
        //Initializes time scale
        Time.timeScale = 1;
    }

    void Start()
    {
        // makes sure inventory isn't active
        inventory.SetActive(false);
    }

    void Update()
    {
        //if tab is pressed activate or deactivate inventory ui depending on the Inventory enabled bool
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryEnabled = !inventoryEnabled;

            //Time scale freezes time while the inventory is active so the player can't move
            if (inventoryEnabled == true )
            {
                //to quiet footsteps
                sendToFootsteps.inventoryOpen = true;

                Time.timeScale = 0;
                inventory.SetActive(true);
            }

            //Inventory closes and timescale resumes as normal
            else 
            {
                //to play footsteps again
                sendToFootsteps.inventoryOpen = false;

                Time.timeScale = 1;
                inventory.SetActive(false);
            }

        }
    }
}
