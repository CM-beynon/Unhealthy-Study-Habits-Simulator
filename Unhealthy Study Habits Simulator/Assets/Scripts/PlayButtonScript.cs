using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

    public AudioSource playingMusic;
    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        Button btn = GameObject.Find("PlayGameButton").GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        // Reset Game Stats
        GameScoreScript.TimeForSleep = 0;
        GameScoreScript.GameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Debug.Log("The game is starting!");
        playingMusic.Pause();
        soundEffect.Play();
        yield return new WaitForSeconds(soundEffect.clip.length);
        SceneManager.LoadScene("GameScene");
    }
}


