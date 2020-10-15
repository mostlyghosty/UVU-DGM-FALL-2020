using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled = false;
    public GameObject inventory;
    public Text[] slots;

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
        //if tab is pressed activate or deactivate inventory ui
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
