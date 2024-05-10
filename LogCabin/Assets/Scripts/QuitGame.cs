using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteKey("prevBuildIndex");
        if (Application.isEditor)
        {
            // Close the game if it's running in the Unity editor
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
