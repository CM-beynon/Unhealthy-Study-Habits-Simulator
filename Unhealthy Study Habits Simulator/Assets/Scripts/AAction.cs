using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAction : MonoBehaviour
{
    bool available;
    string[] stats;
    public PlayerStats player;

    // Start is called before the first frame update
    public virtual void Start()
    {
        available = true;
        string[] temp = {"hunger", "energy", "bathroom"};
        stats = temp;

    } // end Start

    //increase and decrease the relevant player stats
    protected void incStat(string stat, int amount) {
        if (stat.Equals(stats[0])) player.incHunger(amount);
        else if (stat.Equals(stats[1])) player.incEnergy(amount);
        else if (stat.Equals(stats[2])) player.incBathroom(amount);
    }

    //start and end the action, deactivating and reactivating the other action buttons
    //public abstract void startAction();
    //public abstract void endAction();

    //change the speed with which in-game time is advancing
    //public abstract void accelerate();
    //public abstract void decelerate();
}
