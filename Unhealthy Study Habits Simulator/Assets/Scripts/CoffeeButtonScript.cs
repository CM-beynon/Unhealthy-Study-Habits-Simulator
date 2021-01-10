using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeButtonScript : AAction
{
    string actionTag;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button cbtn = GameObject.Find("CoffeeButton").GetComponent<Button>();
        cbtn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TaskOnClick()
    {
        Debug.Log("Caffeinated");
        base.incStat("energy", 2);
    }
}
