using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DecipheredNote : MonoBehaviour
{
    //Send to Scripts
    public Inventory sendToInventory;
    public ItemManagement sendToItemManagement;
    public Footsteps sendToFootsteps;

    //Recieved from scripts, chcks to see if player has opened the deciphered note
    public bool openNote = false;

    //Game Objects in use in this script
    public GameObject inventory;
    public GameObject decipheredNote;

    // Start is called before the first frame update
    void Awake()
    {
        //Makes sure the Deciphered note is not visible to player
        decipheredNote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        //If the player has opened the Deciphered note
        if(openNote == true)
        {
            //clears out of the loop
            openNote = false;

            //closes inventory
            inventory.SetActive(false);
            sendToInventory.inventoryEnabled = false;

            //keeps footsteps from playing while inventory is open
            sendToFootsteps.inventoryOpen = true;


            //Opens Deciphered Note
            decipheredNote.SetActive(true);
            Time.timeScale = 0;

            //checks to see if player has reads the deciphered note and sends that info to Item Manager
            sendToItemManagement.decipheredNote = true;
        }

        //Closes the note
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            decipheredNote.SetActive(false);
        }

    }
}
