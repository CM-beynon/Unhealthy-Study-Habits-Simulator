using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HygieneButtonScript : AAction
{
    string actionTag;
    public Text tooltip;
    public PlayerMovement pMove;
    public AudioSource soundEffect;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Button btn = GameObject.Find("HygieneButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        base.setButton(btn);
        Debug.Log("Started Hygiene Button Script");
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
        Debug.Log("Clean");
        base.incStat("hygiene", 100);
        pMove.setAction("hygiene");
    }

    IEnumerator SoundEffect()
    {
        soundEffect.Play();
        yield return new WaitForSeconds(soundEffect.clip.length);
    }
}