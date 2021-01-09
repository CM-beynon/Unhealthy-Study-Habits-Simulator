using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public const int startHour = 7; // 7PM
    public const int examHour = 7; // 7AM
    public const double timePerMin = 0.25;

    public double nextMin;
    public int timeMin;
    public int timeHour;
    public bool pm;
    public bool gameEnd;

    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        nextMin = Time.time + timePerMin;
        timeMin = 0;
        timeHour = startHour;
        pm = true;
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnd && Time.time >= nextMin)
        {
            nextMin += timePerMin;
            incrementClock();
        }
    }

    void incrementClock()
    {

        if (timeMin + 1 == 60)
        {
            timeMin = 0;
            timeHour = (timeHour + 1) % 12;
            if (timeHour == 0)
            {
                pm = !pm;
            }
        } else
        {
            timeMin++;
        }

        if (timeHour == examHour && !pm) // exam time and in morning
        {
            GameEnd();
        }

        textBox.text = formatTime();
    }

    string formatTime()
    {
        string timeString;

        if (timeHour == 0)
        {
            timeString = "12:";
        } else
        {
            timeString = timeHour.ToString("00") + ":";
        }

        timeString += timeMin.ToString("00");

        if (pm)
        {
            timeString += "PM";
        } else
        {
            timeString += "AM";
        }

        return timeString;
    }

    void GameEnd()
    {
        gameEnd = true;
        // game end code here???
    }
}
