using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    //The collided with item
   private GameObject puzzlePiece;
   public string item;

    //Scripts
   public Inventory sendToInventory;

   public Dialogue sendToDialogue;

   public DecipheredNote sendToDecipheredNote;

    //Timer elements
   private int counter;

   private float time;

   private float timer;

    //info from Mouse events
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

        //when the Mouse events script detects a click and sends it to detect collisions
        if (clickEvent)
        {
            //so the loop doesn't repeat infinitely
            clickEvent = false;                

            //if the knife was used in the area of the spiderweb pick up the siderweb and send info to dialogue
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

            //if the fishing rod was used in the area of the strange gem pick up the strange gem and send info to dialogue
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

            else if (usedItem == "Deciphered Note")
            {
               sendToDecipheredNote.openNote = true;
            }

            //otherwise send that the use of the item was bad to dialouge
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

            //this script is to activate the trigger on the skulls so the dialogue changes
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
