using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public PlayerStats player;
    public bool textVisible = false;
    public double nextTextVisibleToggle;
    public GameObject pauseText;
    public double textInterval = 0.5;

    // Start is called before the first frame update
    void Start()
    {
        nextTextVisibleToggle = Time.time + textInterval;
        Button btn = GameObject.Find("PauseButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        if ((player.getPaused() && Time.time >= nextTextVisibleToggle) || (!player.getPaused() && textVisible))
        {
            textVisible = !textVisible;
            nextTextVisibleToggle += textInterval;
            pauseText.SetActive(textVisible);   
        }
    }

    private void TaskOnClick()
    {
        if (player.getPaused()) // unpause
        {
            Debug.Log("Unpause");
            //textVisible = false;
        } else // pause
        {
            Debug.Log("Pause");
            nextTextVisibleToggle = Time.time;
        }
        player.togglePause();
    }
}
