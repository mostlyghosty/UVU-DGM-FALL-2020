﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //text dialogue
    public string setPiece;
    public Text dialogueBox;
    public GameObject puzzlePiece;

    //bools to set states
    public bool ePress = false;
    private bool startGame = true;
    public bool wrongOrder = false;

    //SFX
    private AudioSource playerAudio;
    public AudioClip pickUp;
    public AudioClip powerOn;

    //Send to typewriter behaviour
    public TypeWriterEffect sendToTypeWriter;
    
    //track item usage
    public string itemUsed;
    public bool clickEvent = false;
    public bool badItem = false;

    //track glow block puzzle solving
    public bool puzzleSolved = false;
    public bool endGame = false;

    //all the dialouge
    private static Dictionary<string, string> dialogue = new Dictionary<string, string>
        {
            {"Start", "If I don't want to be stuck in this temple forever, I'd better look for a way to escape."},
            {"Knife", "It's still as sharp as a ... well, a knife."},
            {"Bone", "Dusty, just like I am."},
            {"Ancient Note", "Hmm, all the pages in these books are blank, except one. I don't recognize the language though."},
            {"Strange Gem", "An, old well. There's something shiny at the bottom but I can't reach it with my stubby arms."},
            {"Spider Web", "It's too sticky to touch. I'll need something to cut it down with."},
            {"Jars", "Filled with darkness."},
            {"Broken Boxes", "They'll fall apart if I touch them and I don't want splinters."},
            {"Table", "Just some old jars."},
            {"Bucket", "It's got too many holes in it to hold anything."},
            {"Crates", "Empty, empty, empty, and empty."},
            {"Sack", "Just sand in here."},
            {"Altar", "It says 'To leave the world you know far behind, light the altar in due time.'"},
            {"Cubes", "I was never one for stonework."},
            {"Secret", "It's a secret to everyone."},
            {"Bad Item", "I can't use this here."},
            {"Wrong Order", "That's not quite right."},
            {"Puzzle Solved", "The altar lit up!"},
            {"Skulls(Clone)", "Alas poor Yorrick... or something like that."},
            {"Books(Clone)", "There's just a book shaped hole in the dust."},
            {"Empty Well(Clone)", "It's dark and scary down there."},
            {"Spiders(Clone)", "Sorry little spider friends."},
            {"Vial(Clone)", "These aren't useful."}

        };

    //secondary dialogue for Item use
    private static Dictionary<string, string> secondDialogue = new Dictionary<string, string>
        {
            {"Strange Gem", "A gemstone! It makes pretty patterns when I look through it."},
            {"Spider Web", "It's... stringy."},
            {"Altar", "The words changed! It says 'May the light of the altar guide your path.'"},
            {"Cubes", "They're crackling with energy."}
        };

    // Start is called before the first frame update
    void Start()
    {
        //initializes the player audio
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is started send intro text to typewriter
        if(startGame)
        {
            startGame = false;
            sendToTypeWriter.textVar = true;
            sendToTypeWriter.fullText = dialogue["Start"];
        }

        //send end dialogue to type writer
        else if (setPiece == "Altar" && endGame && ePress == true)
        {
            ePress = false;
            sendToTypeWriter.textVar = true;
            sendToTypeWriter.fullText = secondDialogue[setPiece];

            sendToTypeWriter.endGame = true;
        }

        //if there was a click event sent from Detect Collisions
        else if (clickEvent == true)
        {
            //to clear loop
            clickEvent = false;

            //if the item use was good send dialogue to typewriter
            if (setPiece != null && setPiece != "Cubes" && !badItem)
            {
                //Play pick up noise
                playerAudio.PlayOneShot(pickUp, 0.3f);

                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = secondDialogue[setPiece];
            }

            //if the set piece from a click event is cubes send dialogue to typewriter
            if (setPiece == "Cubes")
            {
                //play electricity noise
                playerAudio.PlayOneShot(powerOn, 0.3f);

                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = secondDialogue[setPiece];
            }

            //if item use was bad send error message to typewriter
            if (badItem)
            {
                badItem = false;
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = dialogue["Bad Item"];
            }
            
        }

        //if a set piece and an epress was sent over from Item Manager
        else if(setPiece != null && ePress == true)
        {   
            //to clear loop
            ePress = false;
            
            //if the glow block puzzle is solved correctly
            if (puzzleSolved)
            {
                //keeps this from looping
                puzzleSolved = false;

                //send dialogue about puzzle to typewriter
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = dialogue[setPiece];
            }

            //if it's not part of the glow puzzle
            else if (!puzzlePiece.gameObject.CompareTag("Cube"))
            {
                //if it's meant to be picked up play the pickup sound
                if (puzzlePiece != null && puzzlePiece.gameObject.CompareTag("Puzzle Piece"))
                {
                    playerAudio.PlayOneShot(pickUp, 0.3f);
                } 
            
                //send dialogue about item to typewriter
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = dialogue[setPiece];
            }

            //if its part of the glow puzzle and you solved it wrong
            else if (puzzlePiece.gameObject.CompareTag("Cube") && wrongOrder)
            {
                wrongOrder = false;
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = dialogue["Wrong Order"];
            }
            
          
        }

    }

    
}
