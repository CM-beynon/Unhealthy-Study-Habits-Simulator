using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Fields
    private bool action;
    private string actionGoal;
    private Transform start;
    private float startTime;
    private float speed;
    private int endX;
    private int endY;
    private float length;
    private float travelled;
    private float remaining;

    // Start is called before the first frame update
    void Start()
    {
        actionGoal = "None";
        action = false;
        speed = 0.2F;
        start = transform;
        endX = 0;
        endY = 0;
    } // end Start

    // Update is called once per frame
    void Update()
    {
        if(action)
        {
            travelled = (Time.time - startTime) * speed;
            remaining = travelled / length;
            transform.position = Vector3.Lerp(start.position, new Vector3(endX,endY,0), remaining);
            if(transform.position.Equals(new Vector3(endX,endY,0)))
            {
                action = false;
            }
        }
    } // end Update

    public void setAction(string goal)
    {
        if (goal.Equals("Door"))
        {
            endX = 366;
            endY = 260;
        }
        else if(goal.Equals("Coffee"))
        {
            endX = 196;
            endY = 196;
        }

        length = Vector3.Distance(start.position, new Vector3(endX, endY, 0));
        startTime = Time.time;
        action = true;
    } // end setAction
}
