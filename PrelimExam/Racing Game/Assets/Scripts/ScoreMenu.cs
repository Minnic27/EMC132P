using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public static string playernamestr;
    public Text playername;

    public static string timerTextstr;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        playername.text = playernamestr; // receiver of name input from MainMenu
        timerText.text = timerTextstr; // receiver of time string from GameSettings
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // loads MainMenu scene
    }

}
