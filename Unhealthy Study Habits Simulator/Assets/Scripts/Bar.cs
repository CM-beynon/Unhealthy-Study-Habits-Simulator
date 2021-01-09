using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject BG;
    public GameObject fill;
    public Clock timer;
    public static int max = 100;
    public int meter = max;
    public int decreaseInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(BG.transform.position);
        BG.transform.localScale = new Vector3(1f, 1f, 1f);
        BG.transform.localPosition = new Vector3(0f, 0f, 0f);
        fill.transform.localScale = new Vector3(1f, meter, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timeMin % decreaseInterval == 0)
        {
            decrementMeter();
        }
    }

    private void decrementMeter()
    {
        meter -= 1;
        if (meter >= 0)
            fill.transform.localScale = new Vector3(1f, meter, 1f);
        else
            meter = 0;
    }
}
