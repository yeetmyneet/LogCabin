using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Debug.Log("click");
            flashlight.enabled = !flashlight.enabled;
        }

    }
}
