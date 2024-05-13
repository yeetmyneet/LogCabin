using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathScreen : MonoBehaviour
{
    public string endlessModeTrigger = "EndlessTrigger";
    public TMP_Text deathText;
    // Update is called once per frame
    void Awake()
    {
        if (PlayerPrefs.GetInt(endlessModeTrigger, 0) == 1)
        {
            PlayerPrefs.SetInt(endlessModeTrigger, 0);
            float playerTime = PlayerPrefs.GetFloat("StopwatchTime", 0f);
            Debug.Log("Saved time: " + playerTime + " seconds");
            string formattedTime = FormatTime(playerTime);
            deathText.text = "Time Survived: " + formattedTime;
            PlayerPrefs.SetFloat("StopwatchTime", 0f);
        }
    }
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
