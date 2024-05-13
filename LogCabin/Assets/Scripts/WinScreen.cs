using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public string booleanKey = "IsEnabled";
    public string endlessModeTrigger = "EndlessTrigger";
    public TMP_Text timerText;
    void Awake()
    {
        Debug.Log("Awoke win script");
        if (!PlayerPrefs.HasKey(booleanKey))
        {
            PlayerPrefs.SetInt(booleanKey, 0);
            Debug.Log("Created booleanKey");
        }
        PlayerPrefs.SetInt(booleanKey, 1);
        Debug.Log("set booleanKey to true");
        PlayerPrefs.Save();
    }
    void OnApplicationQuit()
    {
        // Delete the PlayerPrefs value when the game exits
        PlayerPrefs.DeleteKey(endlessModeTrigger);
        Debug.Log("Value endlessModeTrigger deleted from PlayerPrefs on application quit.");
    }
}
