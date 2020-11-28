using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleText;
    private bool startFade = true;
    private bool fadeStart = false;

    public GameObject controls;

    private bool controlActive = false;

    private string gameScene = "Game Scene 1";



    void Start()
    {
        controls.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (!controlActive)
        {
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
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            controlActive = true;
            StopCoroutine(Fade());
            controls.SetActive(true);
        }
    }

    public IEnumerator Fade(bool fadeOut = true, float fadeSpeed = 1f)
    {
        //get the color of the square
        Color textColor = titleText.GetComponent<Text>().color;

        Color outlineColor = titleText.GetComponent<Outline>().effectColor;

        //used to calculate how much black squares opacity will change each frame 
        float fadeAmountText;

        float fadeAmountOutline;

        if(fadeOut)
        {
            //loop until black square is fully visible
            while (titleText.GetComponent<Text>().color.a > 0)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmountText = textColor.a - (fadeSpeed * Time.deltaTime);
                fadeAmountOutline = outlineColor.a - (fadeSpeed * Time.deltaTime);

                //creates new color
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmountText);
                outlineColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, fadeAmountOutline);

                //and sets it to the black squares color
                titleText.GetComponent<Text>().color = textColor;
                titleText.GetComponent<Outline>().effectColor = outlineColor;

                yield return null;
            }

            fadeStart = true;
        }

        if (!fadeOut)
        {
            while (titleText.GetComponent<Text>().color.a < 1)
            {
                //adjust fade amount by alpha directly compare to time not frames
                fadeAmountText = textColor.a + (fadeSpeed * Time.deltaTime);
                fadeAmountOutline = outlineColor.a + (fadeSpeed * Time.deltaTime);

                //creates new color
                textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmountText);
                outlineColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, fadeAmountOutline);

                //and sets it to the black squares color
                titleText.GetComponent<Text>().color = textColor;
                titleText.GetComponent<Outline>().effectColor = outlineColor;

                yield return null;
            }

            startFade = true;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
