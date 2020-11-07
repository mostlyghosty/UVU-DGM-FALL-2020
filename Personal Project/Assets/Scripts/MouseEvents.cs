using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseEvents : MonoBehaviour
{
    private GraphicRaycaster slotRaycast;
    private PointerEventData pointerData;
    private EventSystem gameEventSystem; 

    public string useItem;

    public Inventory sendToInventory;

    // Start is called before the first frame update
    void Start()
    {
        slotRaycast = GetComponent<GraphicRaycaster>();
        gameEventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointerData = new PointerEventData(gameEventSystem);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            slotRaycast.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.GetComponent<Text>().text);
                useItem = result.gameObject.GetComponent<Text>().text;
            }

            if (useItem != null && useItem != "")
            {
                GameObject inventory = GameObject.Find("Inventory");
                Time.timeScale = 1;
                inventory.SetActive(false);
                sendToInventory.inventoryEnabled = false;
            }
        }
    }
}
