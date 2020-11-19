using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackSquare;
    public bool endGame;

    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeOut(bool fadeOut = true, int fadeSpeed = 3)
    {
        //get the color of the square
        Color objectColor = blackSquare.GetComponent<Image>().color;

        //used to calculate how much black squares opacity will change each frame 
        float fadeAmount;

        if(fadeOut)
        {
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

            Time.timeScale = 0;
        }

    }
}