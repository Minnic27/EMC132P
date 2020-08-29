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

        GameSettings.playernamestr = playername.text;
        SceneManager.LoadScene("RacingGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
