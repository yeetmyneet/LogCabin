using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float FadeInDelay = 0f;
    [SerializeField] float CanvasRemoveDelay = 6f;
    [SerializeField] float fadeInDuration = 6f;

    void Awake()
    {
        // Get the CanvasGroup component attached to the Canvas
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("found CanvasGroup");

        // Set the CanvasGroup alpha to 0 initially
        canvasGroup.alpha = 0;
        Debug.Log("Set CanvasGroup Alpha to 0.");

        // Start the FadeIn coroutine after the amount of seconds specified
        StartCoroutine(FadeInAfterDelay(FadeInDelay));
        Debug.Log("Starting the fade in");
    }

    IEnumerator FadeInAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        Debug.Log("waiting for specified amount of seconds");

        // Gradually increase the alpha over time
        float duration = fadeInDuration; // Adjust the duration as needed
        float startTime = Time.time;

        while (Time.time - startTime <= duration)
        {
            // Calculate the normalized progress
            float progress = (Time.time - startTime) / duration;
            // Set the CanvasGroup alpha based on the progress
            canvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            // Wait for the next frame
            yield return null;
        }

        // Ensure the final alpha is set to 1
        canvasGroup.alpha = 1f;
        Debug.Log("alpha is finally set to 1, waiting for certain amount of seconds");

        //yield return new WaitForSeconds(CanvasRemoveDelay);
        //Debug.Log("waited for a certain amount of seconds");
        
        //canvasGroup.alpha = 0;
        //Debug.Log("set canvas alpha to 0");

    }
}
