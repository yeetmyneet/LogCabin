using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] Canvas objectiveCanvas;
    [SerializeField] TMP_Text objectiveText;

    private void Awake()
    {
        objectiveCanvas.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            objectiveCanvas.enabled = !objectiveCanvas.enabled;
        }
    }
    public void Objective(string objective)
    {
        objectiveText.text = (objective);
        Debug.Log("changed objective to " + objective);
    }
}
