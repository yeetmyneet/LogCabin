using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60f; // Total time for countdown in seconds
    private float remainingTime;
    [SerializeField] Canvas timer;
    public TMP_Text timerText;
    public GameManager gamemanager;

    void Start()
    {
        remainingTime = totalTime;
        //if (SceneManager.GetActiveScene().buildIndex != 1)
        //{
        //   timerText.gameObject.SetActive(false);
        //   timerWords.gameObject.SetActive(false);
        //}
        timer.enabled = false;
    }

    void Update()
    {
        if (timerText.gameObject.activeSelf)
        {
            remainingTime -= Time.deltaTime;
            // Ensure the timer doesn't go below 0
            remainingTime = Mathf.Max(remainingTime, 0f);
            UpdateTimerUI();

            // Check if the countdown has reached zero
            if (remainingTime <= 0f)
            {
                Debug.Log("Time's up!");
                gamemanager.EndTimer();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            timer.enabled = !timer.enabled;
        }
    }

    void UpdateTimerUI()
    {
        // Format the remaining time into minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        // Update the UI Text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
