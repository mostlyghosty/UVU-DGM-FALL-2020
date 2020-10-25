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

    private bool startGame = true;

    private static Dictionary<string, string> dialogue = new Dictionary<string, string>
        {
            {"Start", "If I don't want to be stuck in this temple forever, I'd better look for a way to escape"},
            {"Knife", "It's still as sharp as a ... well, a knife."},
            {"Bone", "Dusty, just like I am"},
            {"Ancient Note", "Hmm, all the pages in these books are blank, except one. I don't recognize the language though."},
            {"Strange Gem", "There's something shiny at the bottom but I can reach it with my stubby arms."},
            {"Spider Web", "It's too sticky to touch. I'll need something to cut it down with."}
        };

    // Start is called before the first frame update
    void Start()
    {
        //Initializes the timer function
        time = 5f;
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startGame)
        {
            timer -= Time.deltaTime;
            dialogueBox.text = dialogue["Start"];
        }

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
            startGame = false;
            timer = time;
        }

    }

    
}
