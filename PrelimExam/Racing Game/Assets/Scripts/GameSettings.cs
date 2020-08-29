using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{

    public static string playernamestr;
    public Text playername;

    public Text timerText;
    private float startTime;
    private bool finished = false;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; // gives the time when the application starts
        playername.text = playernamestr;
    }

    void Timer()
    {
        if (finished)
        {
            return;
        }
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
}
