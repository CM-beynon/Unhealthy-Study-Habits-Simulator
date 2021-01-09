using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionExample : AAction
{
    string actionTag;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button btn = GameObject.Find("ExampleButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TaskOnClick()
    {
        Debug.Log("Hewwo");
        //base.incStat("hunger", 2);
    }
}
