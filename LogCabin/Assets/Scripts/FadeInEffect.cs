using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float FadeInDelay;
    [SerializeField] float fadeInDuration;

    void Awake()
    {
        
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("found CanvasGroup");

        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        Debug.Log("Set CanvasGroup Alpha to 0.");

        StartCoroutine(FadeInAfterDelay(FadeInDelay));
        Debug.Log("Starting the fade in");
    }

    IEnumerator FadeInAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("waiting for specified amount of seconds");

        // Gradually increase the alpha over time
        float duration = fadeInDuration;
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
        Debug.Log("alpha is finally set to 1");
        canvasGroup.interactable = true;

        //yield return new WaitForSeconds(CanvasRemoveDelay);
        //Debug.Log("waited for a certain amount of seconds");

        //canvasGroup.alpha = 0;
        //Debug.Log("set canvas alpha to 0");

    }
}
