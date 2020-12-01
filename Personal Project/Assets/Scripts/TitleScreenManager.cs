using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    //the game object for flashing text
    public GameObject titleText;

    //bools to make flashing effect loop forever
    private bool startFade = true;
    private bool fadeStart = false;

    //game object for the control scree
    public GameObject controls;

    //tells when the control screen is active
    private bool controlActive = false;

    //used to switch scenes
    private string gameScene = "Game Scene 1";



    void Start()
    {
        //keeps the controls screen from being visible
        controls.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //if the controls are not active
        if (!controlActive)
        {
            //start the couroutine to fade text in and out
            if (startFade)
            {
                startFade = false;
                StartCoroutine(Fade());
            }

            if (fadeStart)
            {
                fadeStart = false;
                StartCoroutine(Fade(false));
            }
        }
        
        //if the control screen is activated
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //sets the controls active bool so prior if statement doesn't run
            controlActive = true;

            //stop the fade coroutine
            StopCoroutine(Fade());

            //make it visible
            controls.SetActive(true);
        }
    }

    public IEnumerator Fade(bool fadeOut = true, float fadeSpeed = 1f)
    {
        //get the color of the tex and outline color
        Color textColor = titleText.GetComponent<Text>().color;

        Color outlineColor = titleText.GetComponent<Outline>().effectColor;

        //used to calculate how much text opacity will change each frame 
        float fadeAmountText;

        float fadeAmountOutline;

        if(fadeOut)
        {
            //loop until the text is fully transparent
            while (titleText.GetComponent<Text>().color.a > 0)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmountText = textColor.a - (fadeSpeed * Time.deltaTime);
                fadeAmountOutline = outlineColor.a - (fadeSpeed * Time.deltaTime);

                //creates new color
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmountText);
                outlineColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, fadeAmountOutline);

                //and sets it to the texty color
                titleText.GetComponent<Text>().color = textColor;
                titleText.GetComponent<Outline>().effectColor = outlineColor;

                yield return null;
            }

            //sets bool so correct if statement runs
            fadeStart = true;
        }

        if (!fadeOut)
        {
            //loop until text is fully visible
            while (titleText.GetComponent<Text>().color.a < 1)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmountText = textColor.a + (fadeSpeed * Time.deltaTime);
                fadeAmountOutline = outlineColor.a + (fadeSpeed * Time.deltaTime);

                //creates new color
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmountText);
                outlineColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, fadeAmountOutline);

                //and sets it to the texts color
                titleText.GetComponent<Text>().color = textColor;
                titleText.GetComponent<Outline>().effectColor = outlineColor;

                yield return null;
            }
            
            //sets bool so correct if statement runs
            startFade = true;
        }
    }

    //loads the game scene when button in game is pressed

    public void NewGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
