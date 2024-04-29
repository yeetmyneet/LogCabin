using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventTriggerController : MonoBehaviour
{
    public Button[] buttons;
    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        Debug.Log("Got Button Components");
    }
    public void DisableEventTriggers(Button button)
    {
        EventTrigger eventTrigger = button.GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            eventTrigger.enabled = false;
        }
        Debug.Log("disabled" + button.name);
    }
    public void EnableEventTriggers(Button button)
    {
        EventTrigger eventTrigger = button.GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
            eventTrigger.enabled = true;
        }
    }
    public void EnableAllEventTriggers()
    {
        foreach (Button button in buttons)
        {
            EnableEventTriggers(button);
        }
        Debug.Log("enabling Event Triggers");
    }
    public void DisableAllEventTriggers()
    {
        foreach (Button button in buttons)
        {
            DisableEventTriggers(button);
        }
        Debug.Log("disabling Event Triggers");
    }
}
