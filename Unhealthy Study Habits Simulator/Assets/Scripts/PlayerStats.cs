using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // meters/status bars
    private int preparedness;
    private int energy;
    public static int maxEnergy = 100;
    private int hunger;
    private int bathroom;

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    } // end Start

    // Update is called once per frame
    void Update()
    {
        
    } // end Update

    public int getPrep()
    {
        return preparedness;
    } // end getPrep

    public int getEnergy()
    {
        return energy;
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

    public void incEnergy(int inc)
    {
        energy += inc;
    } // end incEnergy

    public void incHunger(int inc)
    {
        Debug.Log("Hunger increased");
        Debug.Log(inc);
        hunger += inc;
    } // end incHunger

    public void incBathroom(int inc)
    {
        bathroom += inc;
    } // end incBathroom
} // end PlayerStats
