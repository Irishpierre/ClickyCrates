using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Create a list
    public List<GameObject> targets;

    //Spawn rate
    private float spawnRate = 1.0f;

    //TMP UI
    public TextMeshProUGUI scoreText;
    private int score;

    //Game Over Text
    public TextMeshProUGUI gameOverText;

    //Bool game over toggle
    public bool isGameActive;

    //Button reference
    public Button restartButton;

    //Ref to Title Screen object, holding our UI
    public GameObject titleScreen;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Coroutine
    IEnumerator SpawnTarget()
    {
        //While loop...Spawns targets while the game is active
        while (isGameActive)
        {
            //How fast the targets spawn
            yield return new WaitForSeconds(spawnRate);

            //Selecting which random target within the LIST
            int index = Random.Range(0, targets.Count);

            //Repeat targets within the list
            Instantiate(targets[index]);
        }
    }
    
    //Score update Method
    public void UpdateScore(int scoreAdd)
    {
        //Add score variable
        score += scoreAdd;

        //Get the text to display the score
        scoreText.text = "Score: " + score;
    }

    //GameOver method
    public void GameOver()
    {
        //Setting restart button to true
        restartButton.gameObject.SetActive(true);

        //Allows the game over screen to appear
        gameOverText.gameObject.SetActive(true);

        //Sets game active to false, stops spawns and score
        isGameActive = false;
    }

    //Restart button method
    public void RestartGame()
    {
        //Get reference to the scene to restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Start game method
    public void StartGame(int difficulty)
    {
        //Set game active to true in the beginning
        isGameActive = true;

        //set the score to 0 to start
        score = 0;

        //Setting the difficulty
        spawnRate /= difficulty;

        //Repeating function for spawning targets
        StartCoroutine(SpawnTarget());

        //Score counter method
        UpdateScore(0);
        
        //Disable menu on start
        titleScreen.gameObject.SetActive(false);
    }



}
