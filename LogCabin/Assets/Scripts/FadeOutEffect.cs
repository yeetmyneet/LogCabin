using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float FadeOutDelay;
    [SerializeField] float fadeOutDuration;
    [SerializeField] public AudioSource select;
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 0f);
    }
    public void FadeOut()
    {
        // Get the CanvasGroup component attached to the Canvas
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("found CanvasGroup");

        // Set the CanvasGroup alpha to 0 initially
        canvasGroup.alpha = 1;
        Debug.Log("Set CanvasGroup Alpha to 0.");

        // Start the FadeIn coroutine after the amount of seconds specified
        StartCoroutine(FadeInAfterDelay(FadeOutDelay));
        Debug.Log("Starting the fade in");
    }

    IEnumerator FadeInAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        Debug.Log("waiting for specified amount of seconds");

        // Gradually increase the alpha over time
        float duration = fadeOutDuration; // Adjust the duration as needed
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

        // Ensure the final alpha is set to 1
        canvasGroup.alpha = 0f;
        //Debug.Log("alpha is finally set to 1, waiting for certain amount of seconds");

        //yield return new WaitForSeconds(CanvasRemoveDelay);
        //Debug.Log("waited for a certain amount of seconds");

        //canvasGroup.alpha = 0;
        //Debug.Log("set canvas alpha to 0");

    }
    void QuitGame()
    {
        StartCoroutine(FadeOutAndQuitRoutine());
    }

    IEnumerator FadeOutAndQuitRoutine()
    {
        // Make sure the image is fully transparent at the beginning
        fadeImage.color = new Color(0f, 0f, 0f, 0f);

        // Fade out
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure fully faded
        fadeImage.color = new Color(0f, 0f, 0f, 1f);

        // Quit the application
        Debug.Log("Quitting application");
        Application.Quit();
    }
}
