using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    // variables for string name
    public static string playernamestr;
    public Text playername;

    // variables for string time
    public Text timerText;
    private float startTime;
    private float stopTime;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; // gives the time when the application starts
        playername.text = playernamestr; // receiver of name input from MainMenu
    }

    void Timer()
    {
        // if race is finished
        if (finished)
        {
            return;
        }
        // the timer for the duration of game
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds; // displays text
    }

    // accessed by the player after hitting the FinishLine collider
    public void Finish()
    {
        finished = true;
        ScoreMenu.timerTextstr = timerText.text; // sends the time information to ScoreMenu scene
        timerText.color = Color.red;
        SceneManager.LoadScene("ScoreMenu"); // loads ScoreMenu scene

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
}
