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

    //helps prevent crafting twice
    private bool crafted = false;

    // Update is called once per frame
    void Update()
    {
        //if the combination of items is correct
        if ((draggedItemText == "Bone" && droppedOnText == "Spider Web") || (draggedItemText == "Spider Web" && droppedOnText == "Bone"))
        {
            //clears text to exit the loop
            draggedItemText = "";
            droppedOnText = "";
            
            //changes text to appropriate combinations (crafts item)
            draggedItem.GetComponent<Text>().text = "";
            droppedOn.GetComponent<Text>().text = "Fishing Rod";
        }

        //if the combination of items is correct
        if (!crafted && ((draggedItemText == "Strange Gem" && droppedOnText == "Ancient Note") || (draggedItemText == "Ancient Note" && droppedOnText == "Strange Gem")))
        {
            //clears text to exit the loop
            draggedItemText = "";
            droppedOnText = "";
            
            //changes text to appropriate combinations (crafts item)
            droppedOn.GetComponent<Text>().text = "Deciphered Note";
            draggedItem.GetComponent<Text>().text = "Strange Gem";
        }

        //clears the text to prevent it from being used on a different item accidentally
        else
        {
            droppedOnText = "";
        }
    }
}
