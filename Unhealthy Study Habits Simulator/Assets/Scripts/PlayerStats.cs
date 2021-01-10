using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // meters/status bars
    private int preparedness;
    private int energy;
    private int hunger;
    private int bathroom;
    public static int maxEnergy = 100;
    public static int maxHunger = 100;
    public static int maxBathroom = 100;

    // stop updating if player is paused
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        energy = maxEnergy;
        hunger = maxHunger;
        bathroom = maxBathroom;
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

    public bool getPaused()
    {
        return paused;
    } // end getPrep

    public void incPrep(int inc)
    {
        preparedness += inc;
    } // end incPrep

    public void incEnergy(int inc)
    {
        energy += inc;
        if (energy >= 100) energy = 100;
    } // end incEnergy

    public void incHunger(int inc)
    {
        hunger += inc;
        if (hunger >= 100) hunger = 100;
    } // end incHunger

    public void incBathroom(int inc)
    {
        bathroom += inc;
        if (bathroom >= 100) bathroom = 100;
    } // end incBathroom

    public void togglePause()
    {
        paused = !paused;
    }

    public void GameEnd()
    {
        // save preparedness score and go to end screen
        GameScoreScript.GameScore = preparedness;
        SceneManager.LoadScene("EndScene");
    }
    
} // end PlayerStats
