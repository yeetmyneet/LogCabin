using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOButtonController : MonoBehaviour
{
    public Button[] buttonsToActivate;
    public float fadeInDuration = 1f;
    [SerializeField] EventTriggerController eventControl;

    void Start()
    {
        // Disable buttons interactability initially and set their alpha to 0
        foreach (Button button in buttonsToActivate)
        {
            button.interactable = false;
            button.gameObject.SetActive(false);
            eventControl.DisableAllEventTriggers();
            Debug.Log("disabled event triggers (GOButtonController)");
            Color buttonColor = button.image.color;
            buttonColor.a = 0f;
            button.image.color = buttonColor;
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                Color textColor = buttonText.color;
                textColor.a = 0f;
                buttonText.color = textColor;
            }
        }
        StartCoroutine(ActivateButtonsAfterDelay(5f));
    }

    IEnumerator ActivateButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (Button button in buttonsToActivate)
        {
            button.gameObject.SetActive(true);
            StartCoroutine(FadeButtonIn(button));
        }
    }

    IEnumerator FadeButtonIn(Button button)
    {
        Color buttonColor = button.image.color;

        // Fade in loop
        for (float t = 0; t < 1; t += Time.deltaTime / fadeInDuration)
        {
            buttonColor.a = Mathf.Lerp(0f, 1f, t);
            button.image.color = buttonColor;

            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                Color textColor = buttonText.color;
                textColor.a = Mathf.Lerp(0f, 1f, t);
                buttonText.color = textColor;
            }

            yield return null;
        }

        // Sets button's alpha to 1
        buttonColor.a = 1f;
        button.image.color = buttonColor;
        eventControl.EnableAllEventTriggers();
        Debug.Log("enabled event triggers (GOButtonController)");

        Text finalButtonText = button.GetComponentInChildren<Text>();
        if (finalButtonText != null)
        {
            Color finalTextColor = finalButtonText.color;
            finalTextColor.a = 1f;
            finalButtonText.color = finalTextColor;
        }
        button.interactable = true;
    }
}
