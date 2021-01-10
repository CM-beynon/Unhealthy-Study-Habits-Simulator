using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameScoreScript
{
    private static int gameScore;

    public static int GameScore
    {
        get
        {
            return gameScore;
        } set
        {
            gameScore = value;
        }
    }

    private static int timeForSleep;

    public static int TimeForSleep
    {
        get
        {
            return timeForSleep;
        } set
        {
            timeForSleep = value;
        }
    }

    private static bool procrastinatorMode = false;

    public static bool ProcrastinatorMode
    {
        get
        {
            return procrastinatorMode;
        }
        set
        {
            procrastinatorMode = value;
        }
    }
}
