using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] Light flashlight;
    [SerializeField] AudioSource FL;
    [SerializeField] AudioClip click;

    private void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            FL.pitch = 1f + Random.Range(-0.2f, 0.2f);
            FL.PlayOneShot(click);
            flashlight.enabled = !flashlight.enabled;
        }

    }
}
