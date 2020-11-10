using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{  
    //When a UI inventory object is dragged it follows the mouse position
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    //When that same object is let go it snaps back to it's original spot.
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
    
