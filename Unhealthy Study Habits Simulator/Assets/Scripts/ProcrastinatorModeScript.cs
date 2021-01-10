using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcrastinatorModeScript : MonoBehaviour
{
    public bool procrastinatorMode;
    //public Text procrastinatorText;

    // Start is called before the first frame update
    void Start()
    {
        procrastinatorMode = false;
        Button btn = GameObject.Find("ProcrastinatorModeButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        procrastinatorMode = !procrastinatorMode;
        GameScoreScript.ProcrastinatorMode = procrastinatorMode;
        Debug.Log("You want a challenge? " + procrastinatorMode);

        Text procrastinatorText = GameObject.Find("ProcrastinatorText").GetComponent<Text>();

        if (procrastinatorMode)
        {
            procrastinatorText.color = new Color32(3, 145, 68, 255);
            Debug.Log("Green");
        }
        else
        {
            procrastinatorText.color = new Color32(207, 207, 207, 255);
            Debug.Log("White");
        }
    }
}
