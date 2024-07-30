using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public Button resumeButton;
    public Button restartButton;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(resume);
        restartButton.onClick.AddListener(restart);
        exitButton.onClick.AddListener(exit);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void resume()
    {

    }
    void restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void exit()
    {
        SceneManager.LoadScene("Menu");
    }




}
