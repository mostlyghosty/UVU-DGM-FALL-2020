using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string setPiece;

    public Text dialogueBox;

    private float time;

    private float timer;

    public bool ePress = false;

    private static Dictionary<string, string> dialogue = new Dictionary<string, string>
        {
            {"Knife", "It's Rusty." }
        };

    // Start is called before the first frame update
    void Start()
    {
        //Initializes the timer function
        time = 3f;
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if the setPiece has text in it from detect collisions and detect collisions detected an E Key Press
        if(setPiece != null && ePress == true)
        {   
            //Start timer
            timer -= Time.deltaTime;
            //Send dialogue to the dialoguebox (setPiece is temporary place holder)
            dialogueBox.text = dialogue[setPiece];
        }

        //Once the time runs out reset everything
        if(timer < 0)
        {
            ePress = false;
            setPiece = null;
            dialogueBox.text = null;
            timer = time;
        }

    }

    
}
