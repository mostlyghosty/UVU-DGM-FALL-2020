using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //text dialogue
    public string setPiece;
    public Text dialogueBox;
    public GameObject puzzlePiece;

    //Timer
    private float time;
    private float timer;

    //bools to set states
    public bool ePress = false;
    private bool startGame = true;

    //SFX
    private AudioSource playerAudio;

    public AudioClip pickUp;

    //Send to typewriter behaviour
    public TypeWriterEffect sendToTypeWriter;
    
    //track item usage
    public string itemUsed;

    public bool clickEvent = false;

    public bool badItem = false;

    //all the dialouge
    private static Dictionary<string, string> dialogue = new Dictionary<string, string>
        {
            {"Start", "If I don't want to be stuck in this temple forever, I'd better look for a way to escape."},
            {"Knife", "It's still as sharp as a ... well, a knife."},
            {"Bone", "Dusty, just like I am"},
            {"Ancient Note", "Hmm, all the pages in these books are blank, except one. I don't recognize the language though."},
            {"Strange Gem", "An, old well. There's something shiny at the bottom but I can't reach it with my stubby arms."},
            {"Spider Web", "It's too sticky to touch. I'll need something to cut it down with."},
            {"Jars", "Filled with darkness."},
            {"Broken Boxes", "They'll fall apart if I touch them and I don't want splinters."},
            {"Table", "Just some old jars."},
            {"Bucket", "It's got too many holes in it to hold anything."},
            {"Skulls", "Alas, poor Yorrick... or something like that anyway."},
            {"Crates", "Empty, empty, empty, and empty."},
            {"Sack", "Just sand in here."},
            {"Altar", "It says 'To leave the world you know far behind, light the altar in due time.'"},
            {"Cubes", "I was never one for stonework."},
            {"Secret", "It's a secret to everyone."},
            {"Bad Item", "I can't use this here."}
        };

    //secondary dialogue for Item use
    private static Dictionary<string, string> secondDialogue = new Dictionary<string, string>
        {
            {"Strange Gem", "It makes pretty patterns when I look through it."},
            {"Spider Web", "It's... stringy."},
            {"Altar", "The words changed! It says 'May the light of the altar guide your path.'"}
        };

    // Start is called before the first frame update
    void Start()
    {
        //Initializes the timer function
        time = 5f;
        timer = time;

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(startGame)
        {
            startGame = false;
            timer = time;
            sendToTypeWriter.textVar = true;
            sendToTypeWriter.fullText = dialogue["Start"];
        }

        if (clickEvent == true)
        {
            clickEvent = false;
            timer -= Time.deltaTime;

            if (setPiece != null && !badItem)
            {
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = secondDialogue[setPiece];
            }

            if (badItem)
            {
                badItem = false;
                sendToTypeWriter.textVar = true;
                sendToTypeWriter.fullText = dialogue["Bad Item"];
            }
            
        }


        else if(setPiece != null && ePress == true)
        {   
            ePress = false;
            timer = time;

            if (puzzlePiece != null && puzzlePiece.gameObject.CompareTag("Puzzle Piece"))
            {
                playerAudio.PlayOneShot(pickUp, 0.3f);
            } 
            
            sendToTypeWriter.textVar = true;
            sendToTypeWriter.fullText = dialogue[setPiece];
          
        }

        //Once the time runs out reset everything
        if(timer < 0)
        {
            dialogueBox.text = null;
            timer = time;
        }

    }

    
}
