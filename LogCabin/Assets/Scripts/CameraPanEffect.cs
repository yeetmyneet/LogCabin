using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanEffect : MonoBehaviour
{
    public float zoomedInFOV = 30f; // Field of view when zoomed in
    public float zoomedOutFOV = 60f; // Field of view when zoomed out
    public float duration = 5f; // Duration of the zoom out animation

    private Camera cam;
    private float startTime;
    void Awake()
    {
        cam = GetComponent<Camera>();
        startTime = Time.time;
        cam.fieldOfView = zoomedInFOV;
    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;
        float easedT = EaseOutCubic(t);
        cam.fieldOfView = Mathf.Lerp(zoomedInFOV, zoomedOutFOV, easedT);


        // Ensure the FOV doesn't overshoot
        if (t >= 1.0f)
        {
            cam.fieldOfView = zoomedOutFOV;
            enabled = false; // Disable the script when the animation is complete
        }
    }
    // Ease-out cubic function
    float EaseOutCubic(float x)
    {
        return 1f - Mathf.Pow(1f - x, 3f);
    }
}
