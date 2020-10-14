using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
   private GameObject puzzlePiece;
   public string item;

   public Inventory sendToInventory;

   private int counter;

    void Start ()
    {
        counter = 0;
    }
    void Update()
    {
        if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E))
        {

            sendToInventory.inventoryItems[counter] = item;
            Destroy(puzzlePiece);

            counter += 1;
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
    
            puzzlePiece = other.gameObject;
            item = other.gameObject.name;

    }

    void OnTriggerExit(Collider other)
    {
        item = null;
        puzzlePiece = null;
    }


}
