using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public PlayerStats player;
    public GameObject BG;
    public GameObject fill;
    public Clock timer;
    public int decreaseInterval = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(BG.transform.position);
        BG.transform.localScale = new Vector3(1f, 1f, 1f);
        BG.transform.localPosition = new Vector3(0f, 0f, 0f);
        fill.transform.localScale = new Vector3(1f, player.getEnergy(), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer.timeMin);
        if (timer.timeMin % decreaseInterval == 0)
        {
            decrementMeter();
        }
    }

    private void decrementMeter()
    {
        if (player.getEnergy() >= 1)
        {
            player.incEnergy(-1);
            fill.transform.localScale = new Vector3(1f, player.getEnergy(), 1f);
        }
    }
}
