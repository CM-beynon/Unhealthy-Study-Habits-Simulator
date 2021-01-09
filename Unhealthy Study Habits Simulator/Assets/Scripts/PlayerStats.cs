using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // meters/status bars
    private int preparedness;
    private int tiredness;
    private int hunger;
    private int bathroom;

    // Start is called before the first frame update
    void Start()
    {
        
    } // end Start

    // Update is called once per frame
    void Update()
    {
        
    } // end Update

    public int getPrep()
    {
        return preparedness;
    } // end getPrep

    public int getTired()
    {
        return tiredness;
    } // end getTired

    public int getHunger()
    {
        return hunger;
    } // end getHunger

    public int getBathroom()
    {
        return bathroom;
    } // end getBathroom

    public void incPrep(int inc)
    {
        preparedness += inc;
    } // end incPrep

    public void incTired(int inc)
    {
        tiredness += inc;
    } // end incTired

    public void incHunger(int inc)
    {
         // Debug.Log("Hunger increased");
        //Debug.Log(inc);
        hunger += inc;
    } // end incHunger

    public void incBathroom(int inc)
    {
        bathroom += inc;
    } // end incBathroom
} // end PlayerStats
