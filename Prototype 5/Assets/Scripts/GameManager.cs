using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //list of prefabs
    public List<GameObject> targets;

    //how quickly those prefabs spawn
    private float spawnRate = 1.0f;

    //Keeps track of player score
    private int score;

    //Text and button for UI
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    //control for the while loop
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        //initializes isgameactive bool
        isGameActive = true;

        //initializes score
        score = 0;

        //initializes the score text
        scoreText.text = "Score: " + score;

        //starts the coroutine to begin spawning objects
        StartCoroutine(SpawnTarget());
        
        //sets game over screen to inactive
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false); 
    }

    IEnumerator SpawnTarget()
    {
        //while the game is not over
        while(isGameActive)
        {
            //wait for spawn
            yield return new WaitForSeconds(spawnRate);

            //select a random prefab
            int index = Random.Range(0, targets.Count);

            //then instantiate that prefab
            Instantiate(targets[index]);
        }
    }

    // adds players score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    //reloads the scene to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //activates the game over scene
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
