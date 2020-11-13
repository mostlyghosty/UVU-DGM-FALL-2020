using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{  
    public CraftingHandler sendToCraftingHandler;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        //initializes the canvas group on the slot
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //prevents dragged Item from blocking raycasts underneath it
        canvasGroup.blocksRaycasts = false;

        //sends info about what is being dragged to the crafting handler
        sendToCraftingHandler.draggedItemText = GetComponent<Text>().text;
        sendToCraftingHandler.draggedItem = gameObject;
    }
    
    //When a UI inventory object is dragged it follows the mouse position
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    //When that same object is let go it snaps back to it's original spot.
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }
}
    
