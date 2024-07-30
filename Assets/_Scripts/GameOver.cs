using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Button restartButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assign button click listeners
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        // Display the score
        //scoreText.text = "Your Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOverScreen(int score)
    {
        // Store the score using PlayerPrefs
        PlayerPrefs.SetInt("Score", score);

        // Enable the game over UI
        gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    }

}