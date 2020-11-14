using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftingHandler : MonoBehaviour
{
    //the Game object and the text of the dragged Item
    public string draggedItemText;
    public GameObject draggedItem;

    //the Game object and the text of the item the dragged item is dropped on
    public string droppedOnText;
    public GameObject droppedOn;

    // Update is called once per frame
    void Update()
    {
        //if the combination of items is correct
        if ((draggedItemText == "Bone" && droppedOnText == "Spider Web") || (draggedItemText == "Spider Web" && droppedOnText == "Bone"))
        {
            draggedItemText = "";
            droppedOnText = "";
            Debug.Log("Correct Combination");
            
            draggedItem.GetComponent<Text>().text = "";
            droppedOn.GetComponent<Text>().text = "Fishing Rod";
        }

        //if the combination of items is correct
        if ((draggedItemText == "Strange Gem" && droppedOnText == "Ancient Note") || (draggedItemText == "Ancient Note" && droppedOnText == "Strange Gem"))
        {
            draggedItemText = "";
            droppedOnText = "";
            
            droppedOn.GetComponent<Text>().text = "Deciphered Note";

            Debug.Log("Correct Combination");
        }
    }
}
