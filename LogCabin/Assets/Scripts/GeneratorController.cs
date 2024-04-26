using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorController : MonoBehaviour
{
    #region Inspector References

    public Slider slider;
    public float maxValue = 100f;
    public float decreaseAmount = 1f;
    public float decreaseInterval = 1f;
    public delegate void GeneratorBrokenEventHandler();
    public event GeneratorBrokenEventHandler generatorBroken;
    private float timer;
    [SerializeField] bool generatorWorking = true;
    [SerializeField] InteractingScript interactScript;
    [SerializeField] GameObject[] lights;
    [SerializeField] AudioSource generatorSource;
    [SerializeField] AudioSource playerSource;
    [SerializeField] AudioClip powerOff;

    #endregion Inspector References
    void Start()
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
        timer = decreaseInterval;
        generatorSource = GetComponent<AudioSource>();
        playerSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && generatorWorking)
        {
            slider.value -= decreaseAmount;
            timer = decreaseInterval;

            if (slider.value <= 0) { BreakGenerator(); }
        }
    }

    public void ResetSlider()
    {
        slider.value = maxValue;
        generatorWorking = true;
        LightCheck(0);
        generatorSource.Play();
    }
    void BreakGenerator()
    {
        generatorWorking = false;
        if (generatorBroken != null) { generatorBroken(); }
        generatorSource.Stop();
        playerSource.PlayOneShot(powerOff);
        LightCheck(1);
    }
    void LightCheck(int value)
    {
        if (value == 1)
        {
            foreach (GameObject obj in lights) { obj.SetActive(false); }
        }
        else if (value == 0)
        {
            foreach (GameObject obj in lights) { obj.SetActive(true); }
        }
    }
}
