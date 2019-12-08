using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles UI in game
public class GameUIManager : MonoBehaviour
{
    //Used to reference the game object containing the "Back to menu" button
    public GameObject menuCanvas;
    //Boolean used to toggle the canvas
    private bool toggleMenu;

    //Listens for key press (Esc key) and toggles the menu button
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                ToggleGameMenu();
        }
    }

    //Toggle the menu button
    private void ToggleGameMenu()
    {
        toggleMenu = !toggleMenu;
        menuCanvas.SetActive(toggleMenu);
    }
}
