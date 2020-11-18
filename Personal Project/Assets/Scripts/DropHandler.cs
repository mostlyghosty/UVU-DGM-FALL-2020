using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    //scripts
    public CraftingHandler sendToCraftingHandler;
    public MouseEvents sendToMouseEvents;

    public void OnDrop(PointerEventData eventData)
    {
        //sends information about the Item the dragged Item was dropped on to crafting handler
        sendToCraftingHandler.droppedOnText = GetComponent<Text>().text;
        sendToCraftingHandler.droppedOn = gameObject;

        //sends info to mouse events that the user tried to craft an Item so that the inventory doesn't close and display error text
        sendToMouseEvents.crafted = true;
    }

}
