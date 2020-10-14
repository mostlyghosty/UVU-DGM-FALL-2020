using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private GameObject [] slot;

    public GameObject slotHolder;

    public string[] inventoryItems;

    void Start()
    {
        // makes sure inventory isn't active and initializes time scale
        inventory.SetActive(false);
        Time.timeScale = 1;

        //sets the number of slots in the allSlots array
        allSlots = 9;
        slot = new GameObject[allSlots];

        inventoryItems = new string[10];
    
    }
    void Update()
    {
        //if left shift is pressed activate or deactivate inventory ui
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled == true)
            {
                Time.timeScale = 0;
                inventory.SetActive(true);
            }

            else 
            {
                Time.timeScale = 1;
                inventory.SetActive(false);
            }

        }
    }
}
