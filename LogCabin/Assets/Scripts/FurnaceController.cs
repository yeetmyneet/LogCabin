using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceController : MonoBehaviour
{
    #region Inspector References
    public Slider slider;
    public float maxValue = 100f;
    public float decreaseAmount = 1f;
    public float decreaseInterval = 1f;
    public delegate void FurnaceBrokenEventHandler();
    public event FurnaceBrokenEventHandler furnaceBroken;
    private float timer;
    [SerializeField] bool furnaceWorking = true;
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
        if (timer <= 0f && furnaceWorking)
        {
            slider.value -= decreaseAmount;
            timer = decreaseInterval;

            if (slider.value <= 0)
            {
                BreakFurnace();
            }
        }
    }

    public void ResetSlider()
    {
        slider.value = maxValue;
        StartCoroutine(WaitOneSecond());
        furnaceWorking = true;
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("One second has passed.");
    }
    void BreakFurnace()
    {
        furnaceWorking = false;
        if (furnaceBroken != null)
        {
            furnaceBroken();
        }
    }
}
