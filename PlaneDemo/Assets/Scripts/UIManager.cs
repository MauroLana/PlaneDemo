using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script that handles UI elements
public class UIManager : MonoBehaviour
{
    [Tooltip("Link to the canvas containing game instructions")]
    public GameObject howToPlayCanvas;
    //Bolean variable used to toggle on and off the canvas
    private bool howToPlayActive;
    //Integer used to store score
    private int score;
    //Reference to the UI text field
    private Text scoreTextField;

    private void Start()
    {
        //Finds the UI text field containing the score 
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game")
            scoreTextField = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    }

    //Toggles the canvas How to Play
    public void ToggleHowToPlay()
    {
        howToPlayActive = !howToPlayActive;
        howToPlayCanvas.SetActive(howToPlayActive);
    }

    //Increases score by one
    public void ScoreUp()
    {
        score++;
    }

    //Updated UI text field with score value
    public void UpdateScore()
    {
        scoreTextField.text = score.ToString();
    }


}
