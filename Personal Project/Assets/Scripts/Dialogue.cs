using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //text dialogue
    public string setPiece;
    public Text dialogueBox;

    //Timer
    private float time;
    private float timer;

    //bools to set states
    public bool ePress = false;
    private bool startGame = true;

    //SFX
    public AudioClip[] voiceClips;

    private AudioSource playerAudio;

    private static Dictionary<string, string> dialogue = new Dictionary<string, string>
        {
            {"Start", "If I don't want to be stuck in this temple forever, I'd better look for a way to escape"},
            {"Knife", "It's still as sharp as a ... well, a knife."},
            {"Bone", "Dusty, just like I am"},
            {"Ancient Note", "Hmm, all the pages in these books are blank, except one. I don't recognize the language though."},
            {"Strange Gem", "There's something shiny at the bottom but I can reach it with my stubby arms."},
            {"Spider Web", "It's too sticky to touch. I'll need something to cut it down with."}
        };

    private static Dictionary<string, string> secondDialogue = new Dictionary<string, string>
        {
            {"Strange Gem", "It makes pretty patterns when I look through it."},
            {"Spider Web", "It's... stringy."}
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
            Invoke("RandomSoundGenerator", 0);
            dialogueBox.text = dialogue["Start"];
        }

       /* if (setPiece != null && ePress == true && Item is in inventory)
       {
           timer -= Time.deltaTime;
           dialogueBox.text = secondDialogue[setPiece];
       }*/

        //if the setPiece has text in it from detect collisions and detect collisions detected an E Key Press
        /*should be else for secondary dialogue*/
        if(setPiece != null && ePress == true)
        {   
            ePress = false;
            Invoke("RandomSoundGenerator", 0);
            //Send dialogue to the dialoguebox
            dialogueBox.text = dialogue[setPiece];
        }

        //Once the time runs out reset everything
        if(timer < 0)
        {
            setPiece = null;
            dialogueBox.text = null;
            timer = time;
        }

    }

    void RandomSoundGenerator()
    {
        playerAudio.PlayOneShot(voiceClips[Random.Range(0, voiceClips.Length)], 1.0f);
    }

    
}
