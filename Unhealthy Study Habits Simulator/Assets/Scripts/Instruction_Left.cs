using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction_Left : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        Button left = GameObject.Find("Left").GetComponent<Button>();
        left.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        page1.SetActive(true);
        page2.SetActive(true);
        page3.SetActive(false);
        //this.gameObject.SetActive(false);
        rightArrow.SetActive(true);
    }
}
