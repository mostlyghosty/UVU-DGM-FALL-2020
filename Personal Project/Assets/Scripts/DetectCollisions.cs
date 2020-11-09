using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
   private GameObject puzzlePiece;
   public string item;

   public Inventory sendToInventory;

   public Dialogue sendToDialogue;

   private int counter;

   private float time;

   private float timer;

   public bool clickEvent = false;

   public string usedItem;

   

    void Start ()
    {
        //Initializes the counter for the slot array
        counter = 0;

        time = 2f;
        timer = time;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (clickEvent)
        {
            clickEvent = false;                

            if (item == "Spider Web" && usedItem == "Knife")
            {
                sendToInventory.slots[counter].text = item;

                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                Destroy(puzzlePiece);

                counter += 1;
                timer = time;

                item = null;
                puzzlePiece = null;
            }

            else if (item == "Strange Gem" && usedItem == "Fishing Rod")
            {
                sendToInventory.slots[counter].text = item;

                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                Destroy(puzzlePiece);

                counter += 1;
                timer = time;

                item = null;
                puzzlePiece = null;
            }

            else 
            {
                sendToDialogue.clickEvent = true;
                sendToDialogue.badItem = true;
            }
        }

        //if you are still near the object and e is pressed
        if (puzzlePiece != null && timer < 0 && Input.GetKeyDown(KeyCode.E) && puzzlePiece.gameObject.CompareTag("Puzzle Piece") )
        {
            //sends the object to the inventory script
            sendToInventory.slots[counter].text = item;
                
            //Also sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;
            sendToDialogue.puzzlePiece = puzzlePiece;

            Destroy(puzzlePiece);

            //moves to the next empty space in the slots array in the inventory script
            counter += 1;
            timer = time;

           /* if (item == "Bone")
            {
                public GameObject skulls = GameObject.Find("Skulls");
                public CapsuleCollider skullsCollider = skulls.GetComponent<CapsuleCollider>();

                skullsCollider.isTriger = true;
            } */              
        }
   

        else if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && timer < 0)
        {
            //Sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;

            timer = time;
        }
    }

    //If collision is entered sends the object collided with to an empty game object and gets the name and sends it to a text string
    void OnTriggerEnter(Collider other)
    {
    
        puzzlePiece = other.gameObject;
        item = other.gameObject.name;

    }

    //upon leaving the object's radius clears item and puzzle piece variables
    void OnTriggerExit(Collider other)
    {
        item = null;
        puzzlePiece = null;
    }


}
