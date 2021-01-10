using UnityEngine;
using UnityEngine.UI;

public class StudyBarScript : MonoBehaviour
{
    private static Image StudyBarImage;

    /// <summary>
    /// Sets the study bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetStudyBarValue(float value)
    {
        StudyBarImage.fillAmount = value;
        if(StudyBarImage.fillAmount < 0.2f)
        {
            SetStudyBarColor(Color.red);
        }
        else if(StudyBarImage.fillAmount < 0.4f)
        {
            SetStudyBarColor(Color.yellow);
        }
        else
        {
            SetStudyBarColor(Color.green);
        }
    }

    public static float GetStudyBarValue()
    {
        return StudyBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the study bar color
    /// </summary>
    /// <param name="studyColor">Color </param>
    public static void SetStudyBarColor(Color studyColor)
    {
        StudyBarImage.color = studyColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        StudyBarImage = GetComponent<Image>();
        StudyBarScript.SetStudyBarValue(0);
    }
}