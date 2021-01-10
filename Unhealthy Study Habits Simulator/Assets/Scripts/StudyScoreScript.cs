using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyScoreScript : MonoBehaviour {

    // Start is called before the first frame update
    void Start()
    {
        StudyBarScript.SetStudyBarValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        StudyBarScript.SetStudyBarValue(StudyBarScript.GetStudyBarValue() + 0.01f);
    }
}