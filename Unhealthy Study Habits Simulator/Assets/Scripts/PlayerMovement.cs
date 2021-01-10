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
    private int count;
    private string actionGoal;
    private bool opening;
    private bool halfOpen;
    private bool open;

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
        speed = 0.025F;
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
    } // end Start

    // Update is called once per frame
    void Update()
    {
        if(action)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed);

            if (left && count%50 == 0)
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
            else if (right && count%50 == 0)
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
                if(actionGoal.Equals("Door"))
                {
                    opening = true;
                }
                action = false;
                spriteRend.sprite = MCBack;
                count = 0;
                toChair();
            }
        }

        if(opening)
        {
            if (halfOpen && count%40 == 0 && !open)
            {
                door.sprite = doorOpen;
                open = true;
            }
            else if (count%40 == 0 && !open)
            {
                door.sprite = doorHalf;
                halfOpen = true;
            }
            else if (open && count%40 == 0)
            {
                spriteRend.enabled = false;
                Debug.Log("WHAT");
                opening = false;
                halfOpen = false;
            }
            count++;
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
        walk = true;
        right = true;
        actionGoal = goal;
    } // end setAction

    private void toChair()
    {
    } // end toChair

    public void pause()
    {
        if (action)
            action = false;
        else
            action = true;
    } // end pause
}
