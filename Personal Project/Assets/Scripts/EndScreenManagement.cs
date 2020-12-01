using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManagement : MonoBehaviour
{
    //the game object for "The end" Text
    public GameObject theEnd;

    //the text for how to quit the game
    public GameObject instructions;

    // Update is called once per frame
    void start()
    {
        StartCoroutine(Fade(false, 1));  
    }

    public IEnumerator Fade(bool fadeOut = true, int fadeSpeed = 3)
    {
        
        //initializes color for both game objects
        Color theEndColor = theEnd.GetComponent<Text>().color;

        Color instructionsColor = instructions.GetComponent<Text>().color;

        //used to calculate how much objects opacity will change each frame 
        float fadeAmount;

        if (!fadeOut)
        {
            //fades in "The end"
            while (theEnd.GetComponent<Text>().color.a < 1)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmount = theEndColor.a + (fadeSpeed * Time.deltaTime);

                //creates new color
                theEndColor = new Color(theEndColor.r, theEndColor.g, theEndColor.b, fadeAmount);

                //and sets it to the black squares color
                theEnd.GetComponent<Text>().color = theEndColor;

                //halts everything until the while loop ends
                yield return null;
            }

            //wait for 5 seconds
            yield return new WaitForSecondsRealtime(5);

            //fades in instructions to close game
            while (instructions.GetComponent<Text>().color.a < 1)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmount = instructionsColor.a + (fadeSpeed * Time.deltaTime);

                //creates new color
                instructionsColor = new Color(instructionsColor.r, instructionsColor.g, instructionsColor.b, fadeAmount);

                //and sets it to the black squares color
                instructions.GetComponent<Text>().color = instructionsColor;

                //halts everything until the while loop ends
                yield return null;
            }

            //Wait here while escape is not pressed
           while (!Input.GetKeyDown(KeyCode.Escape))
           {
               yield return null;
           }

            //if escape is pressed quit the game
           if (Input.GetKeyDown(KeyCode.Escape))
           {
               Application.Quit();
           }
        }
    }

}
