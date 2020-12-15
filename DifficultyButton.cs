using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //Button variable
    private Button button;
    //Reference to GameManager script
    private GameManager gameManager;
    //Difficulty variable
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference to the button via editor
        button = GetComponent<Button>();
        //Reference to GameManager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //Use Difficulty function
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        //Use buttons to start the game
        gameManager.StartGame(difficulty);
    }
}
