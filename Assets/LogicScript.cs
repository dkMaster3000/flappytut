using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public Text highScoreText;
    public int highScore = 0;
    public string pphighScore = "highScore";

    public AudioSource scoreSound;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(pphighScore);
        updateHighScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (playerScore > highScore)
        {
            highScore = playerScore;
            updateHighScoreText();
        }

    }

    //[ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            scoreSound.Play();
        }
     
    }

    public void updateHighScoreText()
    {
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
        
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore >= highScore)
        {
            PlayerPrefs.SetInt(pphighScore, highScore);
        }

    }

}
