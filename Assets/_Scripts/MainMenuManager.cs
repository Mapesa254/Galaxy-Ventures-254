using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startButton;
    public Button helpButton;
    public Button quitButton;

    private void Start()
    {
        // Assign button click listeners
        startButton.onClick.AddListener(StartGame);
        helpButton.onClick.AddListener(Openhelp);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Level");
    }

    private void Openhelp()
    {
        // Load the options scene or display options UI
        SceneManager.LoadScene("Help");
    }

    private void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
