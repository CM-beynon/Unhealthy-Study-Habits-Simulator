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
    public AudioSource soundEffect;

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
        StartCoroutine(SoundEffect());
        base.startAction();
        Debug.Log("Eated");
        base.incStat("hunger", 100);
        base.incStat("energy", 40);
        pMove.setAction("food");

    }

    IEnumerator SoundEffect()
    {
        soundEffect.Play();
        yield return new WaitForSeconds(soundEffect.clip.length);
    }
}
