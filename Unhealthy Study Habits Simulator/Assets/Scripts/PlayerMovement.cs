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
    private bool left;
    private bool right;
    private float count;
    private string actionGoal;
    private bool opening;
    private bool halfOpen;
    private bool open;
    private bool goalReached;
    private bool closed;

    public SpriteRenderer door;
    public Sprite doorClosed;
    public Sprite doorHalf;
    public Sprite doorOpen;

    public Sprite MCRight;
    public Sprite MCLeft;
    public Sprite MCLeftWalk;
    public Sprite MCRightWalk;
    public Sprite MCFront;
    public Sprite MCBack;
    public Sprite MCSit;

    // Start is called before the first frame update
    void Start()
    {
        action = false;
        speed = 0.07F;
        start = transform;
        endX = 0;
        endY = 0;
        spriteRend = GetComponent<SpriteRenderer>();
        walk = false;
        left = false;
        right = false;
        count = 0;
        opening = false;
        halfOpen = false;
        opening = false;
        goalReached = false;
        closed = true;
    } // end Start

    // Update is called once per frame
    void FixedUpdate()
    {
        moveToGoal();
        toChair();
    } // end Update

    private void moveToGoal()
    {
        if (action)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
            
            if (right && count % 35 == 0)
            {
                if (walk)
                {
                    spriteRend.sprite = MCRight;
                    walk = false;
                }
                else
                {
                    spriteRend.sprite = MCRightWalk;
                    walk = true;
                }
            }

            count++;

            if (start.position == endPos)
            {
                if (actionGoal.Equals("Door"))
                {
                    opening = true;
                    closed = false;
                }
                else
                {
                    goalReached = true;
                }
                action = false;
                spriteRend.sprite = MCBack;
                count = 0;
                start.position = endPos;
            }
        }

        if (opening)
        {
            if (halfOpen && count % 30 == 0 && !open)
            {
                door.sprite = doorOpen;
                open = true;
            }
            else if (count % 30 == 0 && !open)
            {
                door.sprite = doorHalf;
                halfOpen = true;
            }
            else if (open && count % 30 == 0)
            {
                spriteRend.enabled = false;
                opening = false;
                halfOpen = false;
                goalReached = true;
                count = 0;
            }
            count ++;
        }
    } // end moveToGoal

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
        walk = true;
        right = true;
        actionGoal = goal;
    } // end setAction

    private void toChair()
    {
        if (goalReached)
        {
            if (actionGoal == "Door" && count%30 == 0)
            {
                if(!spriteRend.enabled)
                {
                    spriteRend.enabled = true;
                    spriteRend.sprite = MCFront;
                }
                else if(open)
                {
                    door.sprite = doorHalf;
                    open = false;
                    halfOpen = true;
                }
                else if(halfOpen)
                {
                    door.sprite = doorClosed;
                    halfOpen = false;
                    closed = true;
                    spriteRend.sprite = MCLeft;
                    walk = false;
                    count = 0;
                }
            }
            else if (closed)
            {
                // -326 37 chair
                endX = -326;
                endY = 37;
                endPos = new Vector3((float)endX/72, (float)endY/72, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
                if (count % 35 == 0)
                {
                    if (walk)
                    {
                        spriteRend.sprite = MCLeft;
                        walk = false;
                    }
                    else
                    {
                        spriteRend.sprite = MCLeftWalk;
                        walk = true;
                    }
                }

                if (start.position == endPos)
                {
                    goalReached = false;
                    spriteRend.sprite = MCSit;
                    count = 0;
                }
            }
            count++;
        }
    } // end toChair

    public void pause()
    {
        if (action)
            action = false;
        else
            action = true;
    } // end pause

    public void moveBack()
    {
        goalReached = true;
    } // end moveBack
}
