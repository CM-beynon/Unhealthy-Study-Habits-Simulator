using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatButtonScript : AAction
{
    string actionTag;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button btn = GameObject.Find("EatButton").GetComponent<Button>();
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
        Debug.Log("Eated");
        base.incStat("hunger", 2);

    }
}
