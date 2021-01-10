using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AAction : MonoBehaviour
{
    string[] stats;
    string actionName;
    PlayerStats player;
    Button btn;
    bool previouslyInterative;
    AAction[] actionButtons;

    // Start is called before the first frame update
    public virtual void Start()
    {
        actionName = "unnamed";
        player = GameObject.Find("Player").GetComponent(typeof(PlayerStats)) as PlayerStats;

        string[] temp = { "hunger", "energy", "bathroom","preparedness" };
        stats = temp;
        AAction[] tempActions = { GameObject.Find("PoopButton").GetComponent(typeof(AAction)) as AAction, (AAction)GameObject.Find("CoffeeButton").GetComponent(typeof(AAction)) as AAction, (AAction)GameObject.Find("EatButton").GetComponent(typeof(AAction)) as AAction };
        actionButtons = tempActions;
    } // end Start

    public virtual void Update()
    {

        if (player.getPaused() && btn.interactable == true)
        {
            btn.interactable = false;
            previouslyInterative = true;
        }
        else if (!player.getPaused() && previouslyInterative && btn.interactable == false)
        {
            btn.interactable = true;
            previouslyInterative = false;
        }
        else if (Input.GetKeyDown("e") && btn.interactable == false)
        {
            endAction();
        }
    }

    public void setName(string newName) { actionName = newName; }

    public void setButton(Button button) { btn = button;  }

    private Button getButton() { return btn;  }

    //increase and decrease the relevant player stats
    protected void incStat(string stat, int amount)
    {
        if (stat.Equals(stats[0])) player.incHunger(amount);
        else if (stat.Equals(stats[1])) player.incEnergy(amount);
        else if (stat.Equals(stats[2])) player.incBathroom(amount);
    }

    //start and end the action, deactivating and reactivating the other action buttons
    public void startAction()
    {
        Debug.Log("Made it here");
        for (int i = 0; i < actionButtons.Length; i++)
        {
            actionButtons[i].getButton().interactable = false;
        }
    }

    private void endAction()
    {
        for (int i = 0; i < actionButtons.Length; i++)
        {
            actionButtons[i].getButton().interactable = true;
        }
    }

    //change the speed with which in-game time is advancing
    //public abstract void accelerate();
    //public abstract void decelerate();
}
