using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bar : MonoBehaviour
{
    public PlayerStats player;
    public Clock timer;
    public GameObject BG;
    public GameObject fill;
    public Text status;
    public int decreaseInterval = 10;
    public int PlayerStatChoice;
    private int prevMin = -1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(BG.transform.position);
        BG.transform.localScale = new Vector3(1f, 1f, 1f);
        BG.transform.localPosition = new Vector3(0f, 0f, 0f);
        displayFill();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeMin % decreaseInterval == 0 && timer.timeMin != prevMin)
            decrementMeter();
        prevMin = timer.timeMin;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            updateStatus();
            status.gameObject.SetActive(true);
        }
        else
            status.gameObject.SetActive(false);
    }

    private void decrementMeter()
    {

            switch (PlayerStatChoice)
            {
                case 1:
                    if (player.getEnergy() >= 1){
                    player.incEnergy(-1); }
                    break;
                case 2:
                    if (player.getHunger() >= 1){
                    player.incHunger(-1);
                    }
                    break;
                case 3:
                    if (player.getBathroom() >= 1){
                    player.incBathroom(-1);
                    }
                    break;
            }
            displayFill();
        
    }

    private void displayFill()
    {
        int scale = -1;

        switch (PlayerStatChoice)
        {
            case 1:
                scale = player.getEnergy();
                break;
            case 2:
                scale = player.getHunger();
                break;
            case 3:
                scale = player.getBathroom();
                break;
        }

        fill.transform.localScale = new Vector3(1f, scale, 1f);
    }

    private void updateStatus()
    {
        int curStat = -1;
        int maxStat = -1;

        switch (PlayerStatChoice)
        {
            case 1:
                curStat = player.getEnergy();
                maxStat = PlayerStats.maxEnergy;
                break;
            case 2:
                curStat = player.getHunger();
                maxStat = PlayerStats.maxHunger;
                break;
            case 3:
                curStat = player.getBathroom();
                maxStat = PlayerStats.maxBathroom;
                break;
        }

        status.text = curStat + "/" + maxStat;
    }
}
