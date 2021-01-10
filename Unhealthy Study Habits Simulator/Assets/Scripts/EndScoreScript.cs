using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScoreScript : MonoBehaviour
{
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        string grade;
        if (GameScoreScript.GameScore/10000f > 0.9)
        {
            grade = "A+";
        } else if (GameScoreScript.GameScore / 10000f > 0.8)
        {
            grade = "A";
        }
        else if (GameScoreScript.GameScore / 10000f > 0.7)
        {
            grade = "B";
        }
        else if (GameScoreScript.GameScore / 10000f > 0.6)
        {
            grade = "C";
        }
        else if (GameScoreScript.GameScore / 10000f > 0.5)
        {
            grade = "D";
        } else
        {
            grade = "F";
        }

        textBox.text = grade;
    }
}
