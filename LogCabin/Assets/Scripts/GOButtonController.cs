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

            // Set alpha of the button's image
            Color buttonColor = button.image.color;
            buttonColor.a = 0f;
            button.image.color = buttonColor;

            // Set alpha of the button's text
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                Color textColor = buttonText.color;
                textColor.a = 0f;
                buttonText.color = textColor;
            }
        }

        // Start the coroutine to activate buttons after 5 seconds
        StartCoroutine(ActivateButtonsAfterDelay(5f));
    }

    IEnumerator ActivateButtonsAfterDelay(float delay)
    {
        // Wait for delay
        yield return new WaitForSeconds(delay);

        // Enable buttons after delay and fade them in
        foreach (Button button in buttonsToActivate)
        {
            button.gameObject.SetActive(true);
            StartCoroutine(FadeButtonIn(button));
        }
    }

    IEnumerator FadeButtonIn(Button button)
    {
        // Get the button's image color
        Color buttonColor = button.image.color;

        // Fade in loop
        for (float t = 0; t < 1; t += Time.deltaTime / fadeInDuration)
        {
            // Set the alpha value of the button's image and text based on the current progress
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

        // Ensure the final alpha value is exactly 1 for the button's image and text
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

        // Enable interactability after fade-in
        button.interactable = true;
    }
}
