using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostItScript : MonoBehaviour
{
    public Clock clock;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Final\nExam\nat\n" + clock.formatTime(clock.examHour, 0, false);
    }
}
