using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction_Right : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject leftArrow;

    // Start is called before the first frame update
    void Start()
    {
        Button right = GameObject.Find("Right").GetComponent<Button>();
        right.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);
        page4.SetActive(true);
        //this.gameObject.SetActive(false);
        leftArrow.SetActive(true);
    }
}
