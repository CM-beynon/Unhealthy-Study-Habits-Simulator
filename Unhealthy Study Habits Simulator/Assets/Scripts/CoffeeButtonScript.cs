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
        Button btn = GameObject.Find("CoffeeButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        base.setButton(btn);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    private void TaskOnClick()
    {
        base.startAction();
        Debug.Log("Caffeinated");
        base.incStat("energy", 2);
    }
}
