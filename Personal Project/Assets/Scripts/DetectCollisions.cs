using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
   private GameObject puzzlePiece;
   public string item;

   
    void Update()
    {
        if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E))
        {
            
            Debug.Log(item);
            Destroy(puzzlePiece);
            
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
