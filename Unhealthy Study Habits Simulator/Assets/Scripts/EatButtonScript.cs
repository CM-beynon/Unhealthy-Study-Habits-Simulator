using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EatButtonScript : AAction
{
    string actionTag;
    public Text tooltip;
    public PlayerMovement pMove;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button btn = GameObject.Find("EatButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        base.setButton(btn);
        tooltip.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (EventSystem.current.IsPointerOverGameObject())
            tooltip.gameObject.SetActive(true);
        else
            tooltip.gameObject.SetActive(false);
    }

    private void TaskOnClick()
    {
        base.startAction();
        Debug.Log("Eated");
        base.incStat("hunger", 2);
        pMove.setAction("Door");

    }
}
