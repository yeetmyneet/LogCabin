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
    public float timeThreshold = 10f;
    private float timeSinceReset;
    [SerializeField] bool tooLate = false;
    [SerializeField] GameManager gameManager;
    [SerializeField] float brokenInterval;
    [SerializeField] float brokenTimer = 0f;
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
        brokenTimer += Time.deltaTime;
        if (timer <= 0f && furnaceWorking)
        {
            slider.value -= decreaseAmount;
            timer = decreaseInterval;

            if (slider.value <= 0) { BreakFurnace(); }
        }
        if (brokenTimer >= brokenInterval)
        {
            timeSinceReset++;
            Debug.Log("time since furnace reset: " + timeSinceReset);
            brokenTimer = 0f;
        }
        if (timeSinceReset >= timeThreshold && !tooLate)
        {
            tooLate = true;
            gameManager.SpawnPrefabAtTransform1();
        }
    }

    public void ResetSlider()
    {
        slider.value = maxValue;
        furnaceWorking = true;
    }
    void BreakFurnace()
    {
        furnaceWorking = false;
        if (furnaceBroken != null) { furnaceBroken(); }
    }
}
