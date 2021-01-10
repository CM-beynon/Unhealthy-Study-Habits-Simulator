using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Fields
    private bool action;
    private Transform start;
    private float speed;
    private int endX;
    private int endY;
    private Vector3 endPos;
    private SpriteRenderer spriteRend;
    private bool walk;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
        speed = 0.025F;
        start = transform;
        endX = 0;
        endY = 0;
        spriteRend = GetComponent<SpriteRenderer>();
    } // end Start

    // Update is called once per frame
    void Update()
    {
        if(action)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
            
            if(start.position == endPos)
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

        endPos = new Vector3(endX/72, endY/72, transform.position.z);
        //transform.position = endPos;
        //Debug.Log(endX + " " + endY);
        action = true;
    } // end setAction
}
