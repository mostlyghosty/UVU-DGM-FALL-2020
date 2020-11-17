using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public CraftingHandler sendToCraftingHandler;
    public MouseEvents sendToMouseEvents;
    public void OnDrop(PointerEventData eventData)
    {
        //sends information about the Item the dragged Item was dropped on to crafting handler
        sendToCraftingHandler.droppedOnText = GetComponent<Text>().text;
        sendToCraftingHandler.droppedOn = gameObject;

        sendToMouseEvents.crafted = true;
    }

}
