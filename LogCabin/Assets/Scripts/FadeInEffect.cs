using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeInEffect : MonoBehaviour
{
    #region Variables and Objects
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float FadeInDelay;
    [SerializeField] float fadeInDuration;
    [SerializeField] bool isButtons;
    public GameObject enabledObject;
    [SerializeField] EventTriggerController eventControl;
    #endregion Variables and Objects
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("unlocked cursor");
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
        eventControl.DisableAllEventTriggers();
        yield return new WaitForSeconds(delay);
        Debug.Log("waiting for specified amount of seconds");

        // Gradually increase the alpha over time
        float duration = fadeInDuration;
        float startTime = Time.time;

        // Fade in calculations
        while (Time.time - startTime <= duration)
        {
            float progress = (Time.time - startTime) / duration;
            canvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        Debug.Log("alpha is finally set to 1");
        if (isButtons) { eventControl.EnableAllEventTriggers(); }
        canvasGroup.interactable = true;
    }
}
