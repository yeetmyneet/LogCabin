using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public string booleanKey = "IsEnabled";
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
}
