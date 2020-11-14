using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecipheredNote : MonoBehaviour
{
    public Inventory sendToInventory;

    public bool openNote = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(openNote)
        {
            //closes inventory
            Time.timeScale = 1;
            GameObject inventory = GameObject.Find("Inventory");
            inventory.SetActive(false);
            sendToInventory.inventoryEnabled = false;

            openNote = false;

            //Opens Deciphered Note
            gameObject.SetActive(true);
        }

    }
}
