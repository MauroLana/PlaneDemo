using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script handles all scene changes
public class SceneChanger : MonoBehaviour
{
    //Close the application
    public void QuitGame()
    {
        Application.Quit();
    }
    
    //Not finished/implemented to save of time.
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    //Loads the gameplay scene
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    //Loads the menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
