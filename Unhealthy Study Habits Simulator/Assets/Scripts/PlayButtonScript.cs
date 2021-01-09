using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        Button btn = GameObject.Find("PlayGameButton").GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        SceneManager.LoadScene("SampleScene");
	}
}


