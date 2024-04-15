using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] GameObject flashlight;

    private void Start()
    {
        flashlight.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flashlight.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            flashlight.SetActive(false);
        }

    }
}
