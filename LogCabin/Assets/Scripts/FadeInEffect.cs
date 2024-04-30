using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEffect : MonoBehaviour
{
    #region Variables and Objects
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float FadeInDelay;
    [SerializeField] float fadeInDuration;
    [SerializeField] bool isButtons;
    private string booleanKey = "IsEnabled";
    public GameObject enabledObject;
    [SerializeField] EventTriggerController eventControl;
    #endregion Variables and Objects
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
    public void SaveBoolean(bool value)
    {
        // Convert boolean value to integer (1 for true, 0 for false) and save to PlayerPrefs
        PlayerPrefs.SetInt(booleanKey, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    IEnumerator FadeInAfterDelay(float delay)
    {
        bool isEnabled = PlayerPrefs.GetInt(booleanKey, 1) == 1;
        enabledObject.SetActive(isEnabled);
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
