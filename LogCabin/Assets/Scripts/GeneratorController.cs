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

    #endregion Inspector References
    void Start()
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
        timer = decreaseInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && generatorWorking)
        {
            slider.value -= decreaseAmount;
            timer = decreaseInterval;

            if (slider.value <= 0)
            {
                generatorWorking = false;
                if (generatorBroken != null)
                {
                    generatorBroken();
                }
            }
        }
    }

    public void ResetSlider()
    {
        slider.value = maxValue;
        StartCoroutine(WaitOneSecond());
        generatorWorking = true;
        interactScript.generatorFixed();
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("One second has passed.");
    }
}
