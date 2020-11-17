using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagement : MonoBehaviour
{
    //The collided with item
   private GameObject puzzlePiece;
   public string item;

    //Game object for Glow Cube Puzzle and to activate the altar
   public GameObject glowCubePuzzle;

   public GameObject activeLightOrb;

   public GameObject particles;

    //Scripts
   public Inventory sendToInventory;

   public Dialogue sendToDialogue;

   public DecipheredNote sendToDecipheredNote;

    //increment for slot array
   private int counter;

   //stops user from spamming the 'E' key
   private bool ready = true;


    //info from Mouse events
   public bool clickEvent = false;

   public string usedItem;

   public bool decipheredNote = false;


    void Awake()
    {
        //Hides the Glow Cubes Puzzle
       glowCubePuzzle.SetActive(false);

       //hides the lit orb
       activeLightOrb.SetActive(false);

       //hides particles
       particles.SetActive(false);
    }

    void Start ()
    {
        //Initializes the counter for the slot array
        counter = 0;
    }

    void Update()
    {

        //when the Mouse events script detects a click and sends it to detect collisions
        if (clickEvent)
        {
            //so the loop doesn't repeat infinitely
            clickEvent = false;                

            //if the knife was used in the area of the spiderweb pick up the siderweb and send info to dialogue
            if (item == "Spider Web" && usedItem == "Knife")
            {
                //sends the object to the inventory script
                sendToInventory.slots[counter].text = item;

                //Also sends information about the item to dialogue script
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //Makes the item uninterractable
                puzzlePiece.SetActive(false);

                //moves to the next empty space in the slots array in the inventory script
                counter ++;

                //clears info about the collided with item because you never leave the collider
                item = null;
                puzzlePiece = null;
            }

            //if the fishing rod was used in the area of the strange gem pick up the strange gem and send info to dialogue
            else if (item == "Strange Gem" && usedItem == "Fishing Rod")
            {
                //sends the object to the inventory script
                sendToInventory.slots[counter].text = item;

                //Also sends information about the item to dialogue script
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //Makes the item uninterractable
                puzzlePiece.SetActive(false);

                //moves to the next empty space in the slots array in the inventory script
                counter ++;

                //clears info about the collided with item because you never leave the collider
                item = null;
                puzzlePiece = null;
            }

            //If you use the Strange gem to activate the cubes and you have read the deciphered note
            else if (item == "Cubes" && usedItem == "Strange Gem" && decipheredNote)
            {
                //deactivates the stone blacks and replaces them with glow blocks
                GameObject.Find("Stone Cubes").SetActive(false);
                glowCubePuzzle.SetActive(true);

                //Sends information about cubes to Dialogue
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //clears info about the collided with item because you never leave the collider, so puzzle can be set up
                item = null;
                puzzlePiece = null;
            }

            //If you click on deciphered note, passes responsibility to decipherd note script
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
        if (puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && puzzlePiece.gameObject.CompareTag("Puzzle Piece") )
        {
            //sends the object to the inventory script
            sendToInventory.slots[counter].text = item;
                
            //Also sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;
            sendToDialogue.puzzlePiece = puzzlePiece;

            puzzlePiece.SetActive(false);

            //moves to the next empty space in the slots array in the inventory script
            counter ++;            
        }
   
        //does not collect items, sends info to dialogue
        else if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && ready)
        {
            ready = false;
            //Sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;

            StartCoroutine("SpamStopper");
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

    //waits for 2 seconds and the activates the "E" key again
    IEnumerator SpamStopper()
    {
        yield return new WaitForSecondsRealtime(2f);
        ready = true;
    }


}
