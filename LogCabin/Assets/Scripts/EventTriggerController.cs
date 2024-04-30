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
        EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();
        if (eventTrigger != null) { eventTrigger.enabled = false; }
        else { Debug.LogError("can't find eventTrigger"); }
    }
    public void EnableEventTriggers(GameObject buttonObject)
    {
        EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();
        if (eventTrigger != null) { eventTrigger.enabled = true; }
        else { Debug.LogError("can't find eventTrigger"); }
    }
    public void EnableAllEventTriggers()
    {
        foreach (Button button in buttons) { EnableEventTriggers(button.gameObject); }
    }

    public void DisableAllEventTriggers()
    {
        foreach (Button button in buttons) { DisableEventTriggers(button.gameObject); }
    }
}
