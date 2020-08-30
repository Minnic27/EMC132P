using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField playername;

    // redirects to the RacingGame scene for the game
    public void StartGame()
    {
        Debug.Log("Hello " + playername.text + "! Welcome to the Racing Game");

        GameSettings.playernamestr = playername.text; // pases the name to the RacingGame scene
        ScoreMenu.playernamestr = playername.text; // pases the name to the ScoreMenu scene
        SceneManager.LoadScene("RacingGame"); // loads RacingGame scene
    }

}
