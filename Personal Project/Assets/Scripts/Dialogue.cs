using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string setPiece;

    public Text dialogue;

    private float time;

    private float timer;

    public bool ePress = false;

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
            dialogue.text = setPiece;
        }

        //Once the time runs out reset everything
        if(timer < 0)
        {
            ePress = false;
            setPiece = null;
            dialogue.text = null;
            timer = time;
        }

    }

    
}
