using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathScreen : MonoBehaviour
{
    public string endlessModeTrigger = "EndlessTrigger";
    public TMP_Text deathText;
    public TMP_FontAsset newFont;
    // Update is called once per frame
    void Awake()
    {
        if (PlayerPrefs.GetInt(endlessModeTrigger, 0) == 1)
        {
            float savedTime = PlayerPrefs.GetFloat("StopwatchTime", 0f);
            Debug.Log("Saved time: " + savedTime + " seconds");
            deathText.font = newFont;
            string formattedTime = FormatTime(savedTime);
            deathText.text = "Time Survived: " + formattedTime;
            Debug.Log(deathText.text);
        }
        else
        {
            Debug.Log("no endless mode");
        }
    }
    string FormatTime(float timeInSeconds)
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);

        string formattedMinutes = minutes.ToString("00");
        string formattedSeconds = seconds.ToString("00");

        Debug.Log(formattedMinutes + ":" + formattedSeconds);
        // Combine minutes and seconds with a colon
        return formattedMinutes + ":" + formattedSeconds;
    }
}
