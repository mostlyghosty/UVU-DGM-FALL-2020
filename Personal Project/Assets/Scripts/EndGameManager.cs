using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    //the fade out trigger and object
    public GameObject blackSquare;
    public bool endGame;

    //game objects to take away control from the player
    public GameObject player;
    public GameObject staticPlayer;


    // Update is called once per frame
    void Update()
    {
        //If the end game has been triggered start the fade coroutine
        if (endGame)
        {
            StartCoroutine(Fade());
        }
    }

    public IEnumerator Fade(bool fadeOut = true, int fadeSpeed = 3)
    {
        //get the color of the square
        Color objectColor = blackSquare.GetComponent<Image>().color;

        //used to calculate how much black squares opacity will change each frame 
        float fadeAmount;

        if(fadeOut)
        {
            //clears the loop
            endGame = false;
            
            //sets a dummy player model so the user can't interract with anything
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
            
            //loads the end screen
            SceneManager.LoadScene("EndtheGame");

        }

    }
}
