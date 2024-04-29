using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventTriggerController : MonoBehaviour
{
    public Button[] buttons;
    public void DisableEventTriggers(GameObject buttonObject)
    {
        // Get the EventTrigger component attached to the button
        EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();

        // Check if EventTrigger component is found
        if (eventTrigger != null)
        {
            // Disable all event triggers attached to the button
            eventTrigger.enabled = false;
        }
        else
        {
            Debug.LogError("can't find eventTrigger");
        }
    }

    // Method to enable all EventTriggers within a TextMeshPro button
    public void EnableEventTriggers(GameObject buttonObject)
    {
        // Get the EventTrigger component attached to the button
        EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();

        // Check if EventTrigger component is found
        if (eventTrigger != null)
        {
            // Enable all event triggers attached to the button
            eventTrigger.enabled = true;
        }
        else
        {
            Debug.LogError("can't find eventTrigger");
        }
    }

    // Example method to enable EventTriggers of all buttons
    public void EnableAllEventTriggers()
    {
        // Loop through each button and enable EventTrigger components
        foreach (Button button in buttons)
        {
            EnableEventTriggers(button.gameObject);
        }
    }

    // Method to disable EventTriggers of all buttons
    public void DisableAllEventTriggers()
    {
        // Loop through each button and disable EventTrigger components
        foreach (Button button in buttons)
        {
            DisableEventTriggers(button.gameObject);
        }
    }
}
