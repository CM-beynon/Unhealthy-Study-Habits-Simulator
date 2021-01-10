using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Fields
    private bool action;
    private Transform start;
    private float startTime;
    private float speed;
    private int endX;
    private int endY;
    private float length;
    private float travelled;
    private float fraction;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
        speed = 1.0F;
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
            fraction = travelled/length;
            Debug.Log(fraction + " " + travelled);
            transform.position = Vector3.Lerp(start.position, new Vector3(endX,endY,transform.position.z), fraction);
            if(transform.position.Equals(new Vector3(endX,endY,transform.position.z)))
            {
                action = false;
            }
        }
    } // end Update

    public void setAction(string goal)
    {
        if (goal.Equals("Door"))
        {
            endX = 433;
            endY = 271;
        }
        else if(goal.Equals("Coffee"))
        {
            endX = 241;
            endY = 281;
        }

        length = Vector3.Distance(start.position, new Vector3(endX, endY, transform.position.z));
        Debug.Log("LENGTH " + length);
        startTime = Time.time;
        action = true;
    } // end setAction
}
