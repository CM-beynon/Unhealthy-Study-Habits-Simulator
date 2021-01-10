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
    private bool paused;
    private string[] targets;

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
    
    public AudioSource coffeeEffect;
    public AudioSource toiletEffect;
    public AudioSource foodEffect;
    public AudioSource showerEffect;
    public AAction anyButton;

    private StudyScoreScript studyBar;

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
        paused = false;
        string[] temp = { "coffee", "bathroom", "food", "hygiene" };
        targets = temp;
        studyBar = GetComponent<StudyScoreScript>();
    } // end Start

    // Update is called once per frame
    void FixedUpdate()
    {
        moveToGoal();
        toChair();
    } // end Update

    private void moveToGoal()
    {
        if (action && !paused)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed);
            
            if (right && count % 20 == 0)
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
                if (actionGoal.Equals("bathroom") || actionGoal.Equals("food") || actionGoal.Equals("hygiene"))
                {
                    opening = true;
                    closed = false;
                }
                else
                {
                    StartCoroutine(PlaySoundEffect(actionGoal));
                }
                action = false;
                spriteRend.sprite = MCBack;
                count = 0;
                start.position = endPos;
            }
        }

        if (opening && !paused)
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
                StartCoroutine(PlaySoundEffect(actionGoal));
                count = 0;
            }
            count ++;
        }
    } // end moveToGoal

    public void setAction(string goal)
    {
        if (goal.Equals("bathroom") || goal.Equals("food") || goal.Equals("hygiene"))
        {
            endX = 433;
            endY = 271;
        }
        else if(goal.Equals("coffee"))
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
        count = 0;
        studyBar.move();
    } // end setAction

    private void toChair()
    {
        if (goalReached && !paused)
        {
            if ((actionGoal.Equals("bathroom") || actionGoal.Equals("food") || actionGoal.Equals("hygiene")) && count%30 == 0)
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
                if (count % 20 == 0)
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
                    anyButton.endAction();
                    studyBar.move();
                }
            }
            count++;
        }
    } // end toChair

    public void pause()
    {
        if (paused)
            paused = false;
        else
            paused = true;
    } // end pause

    public void moveBack()
    {
        goalReached = true;
    } // end moveBack


    IEnumerator PlaySoundEffect(string target)
    {
        if(target.Equals(targets[0]))
        {
            coffeeEffect.Play();
            yield return new WaitForSeconds(coffeeEffect.clip.length);
        }
        else if(target.Equals(targets[1]))
        {
            toiletEffect.Play();
            yield return new WaitForSeconds(toiletEffect.clip.length);
        }
        else if (target.Equals(targets[2]))
        {
            foodEffect.Play();
            yield return new WaitForSeconds(foodEffect.clip.length);
        }
        else if (target.Equals(targets[3]))
        {
            showerEffect.Play();
            yield return new WaitForSeconds(showerEffect.clip.length);
        }

        goalReached = true;
    }
}
