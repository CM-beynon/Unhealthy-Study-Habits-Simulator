using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsScript : MonoBehaviour
{

    public AudioSource playingMusic;
    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        Button btn = GameObject.Find("InstructionsButton").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        Debug.Log("Going to Instructions");
        playingMusic.Pause();
        soundEffect.Play();
        yield return new WaitForSeconds(soundEffect.clip.length);
        SceneManager.LoadScene("InstructionsScene");
    }
}