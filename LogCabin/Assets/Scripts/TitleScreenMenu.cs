using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour
{
    public AudioClip soundClip;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;
    [SerializeField] public string NextLevel;
    public bool debugMode = true;
    void Start()
    {
        canvasGroup.alpha = 0f;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && debugMode)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
    IEnumerator FadeIn()
    {
        // Disable interaction during fade-in
        canvasGroup.interactable = false;
        // Gradually increase the alpha over time
        float duration = fadeDuration; // Adjust the duration as needed
        float startTime = Time.time;

        while (Time.time - startTime <= duration)
        {
            // Calculate the normalized progress
            float progress = (Time.time - startTime) / duration;
            // Set the CanvasGroup alpha based on the progress (fade in)
            canvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            // Wait for the next frame
            yield return null;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
    }
    IEnumerator WaitAndPlaySound(float waitTime)
    {
        // Wait for the specified time
        StopAllSounds();
        canvasGroup.interactable = false;
        PlaySound();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(NextLevel);
    }

    void PlaySound()
    {
        // Check if an audio clip is assigned
        if (soundClip != null)
        {
            // Play the assigned audio clip
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for sound play.");
        }
    }
    public void StartGame()
    {
        // Start the coroutine to wait and play the sound
        StartCoroutine(WaitAndPlaySound(2f));
    }

   IEnumerator FadeOut()
    {
        Debug.Log("Fadeout");
        // Gradually increase the alpha over time
        float duration = 1f; // Adjust the duration as needed
        float startTime = Time.time;

        while (Time.time - startTime <= duration)
        {
            // Calculate the normalized progress
            float progress = (Time.time - startTime) / duration;
            // Set the CanvasGroup alpha based on the progress
            canvasGroup.alpha = Mathf.Lerp(1, 0, progress);
            // Wait for the next frame
            yield return null;
        }
        canvasGroup.alpha = 0f;
        Debug.Log("Finished Fadeout");
    }
    public void ExitGame()
    {
        StartCoroutine(FadeOutExit());
    }
    void StopAllSounds()
    {
        // Find all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Iterate through each AudioSource and stop it
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
    }
    IEnumerator FadeOutExit()
    {
        Debug.Log("Trying to quit game");
        // Check if the application is running in the Unity Editor
        // Gradually increase the alpha over time
        float duration = 1f; // Adjust the duration as needed
        float startTime = Time.time;

        while (Time.time - startTime <= duration)
        {
            // Calculate the normalized progress
            float progress = (Time.time - startTime) / duration;
            // Set the CanvasGroup alpha based on the progress
            canvasGroup.alpha = Mathf.Lerp(1, 0, progress);
            // Wait for the next frame
            yield return null;
        }
        canvasGroup.alpha = 0f;
        Debug.Log("Finished Fadeout");
        StopAllSounds();
        Application.Quit();
    }
    public void NoFadeIn()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
    }
}
   
