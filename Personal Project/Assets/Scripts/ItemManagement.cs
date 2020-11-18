using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagement : MonoBehaviour
{
    //a collided with item
   private GameObject puzzlePiece;
   public string item;

    //Game objects for Glow Cube Puzzle and to activate the altar
   public GameObject glowCubePuzzle;
   public GameObject activeLightOrb;
   public GameObject particles;
   public GameObject stoneCubes;

    //Scripts
   public Inventory sendToInventory;
   public Dialogue sendToDialogue;
   public DecipheredNote sendToDecipheredNote;

    //increment for slot array
   private int counter;

   //stops user from spamming the 'E' key
   private bool ready = true;


    //info from Mouse events
   public bool clickEvent = false;
   public string usedItem;
   public bool decipheredNote = false;

    // for Glow block puzzle
    public bool oneCorrect;
    public bool twoCorrect;
    public bool solved = false;

    //SFX
    public AudioSource playerAudio;
    public AudioClip click;
    public AudioClip success;
    public AudioClip failure;
    public AudioClip paperSound;


    void Awake()
    {
        //Hides the Glow Cubes Puzzle
       glowCubePuzzle.SetActive(false);

       //hides the lit orb
       activeLightOrb.SetActive(false);

       //hides particles
       particles.SetActive(false);
    }

    void Start ()
    {
        //Initializes the counter for the slot array
        counter = 0;

        //initializes the audio
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {

        //when the Mouse events script detects a click and sends it over
        if (clickEvent)
        {
            //so the loop doesn't repeat infinitely
            clickEvent = false;                

            //if the knife was used in the area of the spiderweb pick up the siderweb and send info to dialogue
            if (item == "Spider Web" && usedItem == "Knife")
            {
                //sends the object to the inventory script
                sendToInventory.slots[counter].text = item;

                //Also sends information about the item to dialogue script
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //Makes the item uninterractable
                puzzlePiece.SetActive(false);

                //moves to the next empty space in the slots array in the inventory script
                counter ++;

                //clears info about the collided with item because you never leave the collider
                item = null;
                puzzlePiece = null;
            }

            //if the fishing rod was used in the area of the strange gem pick up the strange gem and send info to dialogue
            else if (item == "Strange Gem" && usedItem == "Fishing Rod")
            {
                //sends the object to the inventory script
                sendToInventory.slots[counter].text = item;

                //Also sends information about the item to dialogue script
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //Makes the item uninterractable
                puzzlePiece.SetActive(false);

                //moves to the next empty space in the slots array in the inventory script
                counter ++;

                //clears info about the collided with item because you never leave the collider
                item = null;
                puzzlePiece = null;
            }

            //If you use the Strange gem to activate the cubes and you have read the deciphered note
            else if (item == "Cubes" && usedItem == "Strange Gem" && decipheredNote)
            {
                //deactivates the stone blacks and replaces them with glow blocks
                stoneCubes.SetActive(false);
                glowCubePuzzle.SetActive(true);

                //Sends information about cubes to Dialogue
                sendToDialogue.setPiece = item;
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.clickEvent = true;

                //clears info about the collided with item because you never leave the collider, so puzzle can be set up
                item = null;
                puzzlePiece = null;
            }

            //If you click on deciphered note, passes responsibility to decipherd note script
            else if (usedItem == "Deciphered Note")
            {
                //plays paper sound
                playerAudio.PlayOneShot(paperSound, 0.7f);
               sendToDecipheredNote.openNote = true;
            }

            //otherwise send that the use of the item was bad to dialouge
            else
            {
                sendToDialogue.clickEvent = true;
                sendToDialogue.badItem = true;
            }
        }

        //if you are still near an object and e is pressed and it's a collectible item
        if (puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && puzzlePiece.gameObject.CompareTag("Puzzle Piece") )
        {
            //sends the object to the inventory script
            sendToInventory.slots[counter].text = item;
                
            //Also sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.ePress = true;
            sendToDialogue.puzzlePiece = puzzlePiece;

            //makes the collectible uniteractable
            puzzlePiece.SetActive(false);

            //moves to the next empty space in the slots array in the inventory script
            counter ++;  

            //clears info about the collided with item because you never leave the collider, so puzzle can be set up
            item = null;
            puzzlePiece = null;          
        }
   
        //does not collect items, sends info to dialogue, checks to see if you're interracting with the glow cube puzzle
        else if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && ready && !puzzlePiece.gameObject.CompareTag("Cube"))
        {
            ready = false;
            //Sends information about the item to dialogue script
            sendToDialogue.setPiece = item;
            sendToDialogue.puzzlePiece = puzzlePiece;
            sendToDialogue.ePress = true;

            //stops the user from spamming the 'E' key
            StartCoroutine("SpamStopper");
        }


        //if you interract with the glow cubes after reading the deciphered note and activating them
        else if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E) && puzzlePiece.gameObject.CompareTag("Cube") && !solved)
        {
            //initializes bool to tell if the players puzzle solving is going correctly
            bool goodPuzzle = false;
            
            //if the player interracts with clow cube 0
            if (item == "Glow Cube 0")
            {
                //clears item
                item = null;

                //lets script know puzzle is correct so far
                goodPuzzle = true;
                oneCorrect = true;

                //plays confirmation noise
                playerAudio.PlayOneShot(click, 1.5f);
            }

            //if the player interracts with Glow cube 2 and previously interracted with glow cube 0
            if (oneCorrect && item == "Glow Cube 2")
            {
                //clears item
                item = null;

                //lets script know puzzle is correct so far
                goodPuzzle = true;
                twoCorrect = true;

                //plays confirmation noise
                playerAudio.PlayOneShot(click, 1.5f);
            }

            //if whole puzzle is correct
            if (twoCorrect && item == "Glow Cube 1")
            {
                //the puzzle has been permanently solved
                solved = true;

                //clears item
                item = null;

                //lets the script know the puzzle is correct
                goodPuzzle = true;

                //playes success audio
                playerAudio.PlayOneShot(success, 0.3f);

                //Turns off the glow blocks and activates the altar
                stoneCubes.SetActive(true);
                glowCubePuzzle.SetActive(false);
                activeLightOrb.SetActive(true);
                particles.SetActive(true);

                //sends info about the puzzle being solved to dialogue
                sendToDialogue.ePress = true;
                sendToDialogue.setPiece = "Puzzle Solved";
                sendToDialogue.endGame = true;
            }

            //if the puzzle is not correct
            if (!goodPuzzle)
            {
                //send the info to dialogue
                sendToDialogue.puzzlePiece = puzzlePiece;
                sendToDialogue.ePress = true;
                sendToDialogue.wrongOrder = true;

                //clears puzzle progress
                oneCorrect = false;
                twoCorrect = false;

                //plays failure audio
                playerAudio.PlayOneShot(failure, 0.3f);
            }
        }

    }

    //If collision is entered sends the object collided with to an empty game object and gets the name and sends it to a text string
    void OnTriggerEnter(Collider other)
    {
    
        puzzlePiece = other.gameObject;
        item = other.gameObject.name;

    }

    //upon leaving the object's radius clears item and puzzle piece variables
    void OnTriggerExit(Collider other)
    {
        item = null;
        puzzlePiece = null;
    }

    //waits for 2 seconds and the activates the "E" key again
    IEnumerator SpamStopper()
    {
        yield return new WaitForSecondsRealtime(2f);
        ready = true;
    }


}
