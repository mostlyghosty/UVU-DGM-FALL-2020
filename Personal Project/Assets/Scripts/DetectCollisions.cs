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

   public bool correctItem = false;

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

        //if you are still near the object and e is pressed
        if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && puzzlePiece.gameObject.CompareTag("Puzzle Piece") && timer < 0)
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
        }

        else if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && timer < 0)
        {
            //Sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;

            timer = time;
        }

        else if(correctItem && timer < 0)
        {
            correctItem = false;

            sendToInventory.slots[counter].text = item;

            Destroy(puzzlePiece);
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
