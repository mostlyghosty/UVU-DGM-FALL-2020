using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    //the delay it will wait before showing each new character
    public float delay = 0.07f;
    //What is shown when the text is fully displayed
    public string fullText;

    public bool textVar;

    //starts empty
    private string currentText = "";

    //SFX
    public AudioClip[] textClips;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
         playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (textVar)
        {
            textVar = false;
            StartCoroutine(ShowText ());
        }
    }

    IEnumerator ShowText ()
    {
        //for the number of characters in full text plus 1
        for (int i = 0; i < (fullText.Length + 1); i++)
        {
            //make current text a substring of full text, substring goes from 0 to i
            currentText = fullText.Substring(0,i);

            this.GetComponent<Text>().text = currentText;
            if (i > 1)
            {
                Invoke("RandomSoundGenerator", 0);
            }

            //must use IEnumerator function to use WaitForSeconds
            yield return new WaitForSeconds(delay);
        }
    }

    void RandomSoundGenerator()
    {
        playerAudio.PlayOneShot(textClips[Random.Range(0, textClips.Length)], 0.1f);
    }
}
