using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("PauseButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Debug.Log("Toggled Pause");
        player.togglePause();
    }
}
