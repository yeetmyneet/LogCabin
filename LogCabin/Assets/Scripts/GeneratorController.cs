using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorController : MonoBehaviour
{
    public Slider slider;
    public float maxValue = 100f;
    public float decreaseAmount = 1f;
    public float decreaseInterval = 1f;

    private float timer;

    void Start()
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
        timer = decreaseInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            slider.value -= decreaseAmount;
            Debug.Log("decreased generator value");
            timer = decreaseInterval;
        }
    }

    public void ResetSlider()
    {
        slider.value = maxValue;
        Debug.Log("Reset Generator value");
    }
}
