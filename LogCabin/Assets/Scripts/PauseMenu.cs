using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject[] objectsToDisableOnPause; // Array of objects to disable
    public GameObject[] uiElementsToShowOnPause; // Array of UI elements to show on pause
    void Update()
    {
        // Check for input or condition to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        // Pause or resume the game based on the isPaused state
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game

        // Disable specified objects
        foreach (GameObject obj in objectsToDisableOnPause)
        {
            obj.SetActive(false);
        }

        // Show specified UI elements
        foreach (GameObject uiElement in uiElementsToShowOnPause)
        {
            uiElement.SetActive(true);
        }

        // Add other pause-related actions if needed
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Set time scale to 1 to resume the game

        // Enable specified objects
        foreach (GameObject obj in objectsToDisableOnPause)
        {
            obj.SetActive(true);
        }

        // Hide specified UI elements
        foreach (GameObject uiElement in uiElementsToShowOnPause)
        {
            uiElement.SetActive(false);
        }

        // Add other resume-related actions if needed
    }
    public void QuitGame()
    {
        // Set boolean value to true
        PlayerPrefs.SetInt("ComingFromGame", 1);
        PlayerPrefs.Save(); // Save the changes
        SceneManager.LoadScene("TitleScreen");
    }
}
