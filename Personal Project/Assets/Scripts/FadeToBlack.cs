using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackSquare;
    public bool endGame;

    public GameObject theEnd;
    private bool fadeIn = false;

    public GameObject player;
    public GameObject staticPlayer;

    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            StartCoroutine(Fade());
        }

        if (fadeIn)
        {   
            fadeIn = false;
            StartCoroutine(Fade(false, 1));
        }
    }

    public IEnumerator Fade(bool fadeOut = true, int fadeSpeed = 3)
    {
        //get the color of the square
        Color objectColor = blackSquare.GetComponent<Image>().color;

        Color theEndColor = theEnd.GetComponent<Text>().color;

        //used to calculate how much black squares opacity will change each frame 
        float fadeAmount;

        

        if(fadeOut)
        {
            endGame = false;
            
            Vector3 playerPosition = player.transform.position;
            Quaternion playerRotation = player.transform.rotation;
            player.SetActive(false);

            Instantiate(staticPlayer, playerPosition, playerRotation);

            //loop until black square is fully visible
            while (blackSquare.GetComponent<Image>().color.a < 1)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                //creates new color
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

                //and sets it to the black squares color
                blackSquare.GetComponent<Image>().color = objectColor;

                //halts everything until the while loop ends
                yield return null;
            }

            fadeIn = true;
        }

        if (!fadeOut)
        {
            fadeIn = false;

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

           while (!Input.GetKeyDown(KeyCode.Escape))
           {
               yield return null;
           }

           if (Input.GetKeyDown(KeyCode.Escape))
           {
               Application.Quit();
           }
        }
    }
}
