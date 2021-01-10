using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Bar : MonoBehaviour
{
    public PlayerStats player;
    public Clock timer;
    public Image fill;
    public Text status;
    public int decreaseInterval = 10;
    public int PlayerStatChoice;
    private int prevMin = -1;

    // Start is called before the first frame update
    void Start()
    {
        displayFill();
    }

    // Update is called once per frame
    void Update()
    {
        updateStatus();
        if (timer.timeMin % decreaseInterval == 0 && timer.timeMin != prevMin)
        {
            decrementMeter();
            displayFill();
        }
        prevMin = timer.timeMin;
    }

    private void decrementMeter()
    {
        if (!player.getPaused())
        {
            switch (PlayerStatChoice)
            {
                case 1:
                    if (player.getEnergy() >= 1)
                    {
                        player.incEnergy(-1);
                    } else
                    {
                        player.GameEnd();
                    }
                    break;
                case 2:
                    if (player.getHunger() >= 1)
                    {
                        player.incHunger(-1);
                    } else
                    {
                        player.GameEnd();
                    }
                    break;
                case 3:
                    if (player.getBathroom() >= 1)
                    {
                        player.incBathroom(-1);
                    } else
                    {
                        player.GameEnd();
                    }
                    break;
            }
        }
    }

    private void displayFill()
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

        fill.fillAmount = (float) curStat / (float) maxStat;
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
