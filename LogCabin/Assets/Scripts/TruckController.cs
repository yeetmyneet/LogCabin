using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    [SerializeField] InteractingScript interactScript;
    public Collider gasCollider;
    [SerializeField] bool hasGas;
    [SerializeField] ObjectiveUI objectiveUI;
    [SerializeField] TextMeshProUGUI nextObj;
    void Awake()
    {
        hasGas = false;
        gasCollider.enabled = false;
        Debug.Log("truck exit collider disabled");
        interactScript.truckOutOfGas = true;
    }
    void Update()
    {
        // Check if hasGas is true and enable gas collider if so
        if (hasGas)
        {
            gasCollider.enabled = true;
        }
    }
    public void FixTruck()
    {
        gasCollider.enabled = true;
        hasGas = true;
        Debug.Log("truck exit collider enabled");
        objectiveUI.Objective("Explore or Leave");
        nextObj.text = " ";
    }

}
