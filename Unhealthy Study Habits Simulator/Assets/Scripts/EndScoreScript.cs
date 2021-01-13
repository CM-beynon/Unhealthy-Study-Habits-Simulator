using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScoreScript : MonoBehaviour
{
    public Text textBox;

    private float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 8250f;
        string grade;
        if (GameScoreScript.GameScore/multiplier > 0.9)
        {
            grade = "A+";
        } else if (GameScoreScript.GameScore / multiplier > 0.8)
        {
            grade = "A";
        }
        else if (GameScoreScript.GameScore / multiplier > 0.7)
        {
            grade = "B";
        }
        else if (GameScoreScript.GameScore / multiplier > 0.6)
        {
            grade = "C";
        }
        else if (GameScoreScript.GameScore / multiplier > 0.5)
        {
            grade = "D";
        } else
        {
            grade = "F";
        }

        textBox.text = grade;
    }
}
