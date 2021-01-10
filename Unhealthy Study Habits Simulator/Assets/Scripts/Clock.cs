using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public int startHour = 7; // 7PM
    public int examHour = 7; // 7AM
    public double timePerMin = 0.25;

    public double nextMin;
    public int timeMin;
    public int timeHour;
    public bool pm;
    public bool gameEnd;

    public Text textBox;
    public PlayerStats player;

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
            if (!player.getPaused())
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

        textBox.text = formatTime(timeHour, timeMin, pm);
    }

    public string formatTime(int theHour, int theMin, bool isPM)
    {
        string timeString;

        if (theHour == 0)
        {
            timeString = "12:";
        } else
        {
            timeString = theHour.ToString("00") + ":";
        }

        timeString += theMin.ToString("00");

        if (isPM)
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
