using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyScoreScript : MonoBehaviour {
    public PlayerStats player;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        StudyBarScript.SetStudyBarValue(0);
        moving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player.getPaused() && !moving){
            player.incPrep(2);
            StudyBarScript.SetStudyBarValue(player.getPrep()/7500f);
        }
    }

    public void move()
    {
        if (moving)
            moving = false;
        else
            moving = true;
        Debug.Log(moving);
    }
}