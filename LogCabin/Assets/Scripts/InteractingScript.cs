using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractingScript : MonoBehaviour
{
    #region Variables and Objects 

    string generatorTag = "Generator";
    string furnaceTag = "Furnace";
    string radioTag = "Radio";
    public GameObject objectToShow;
    public Slider slider;
    public GameObject sliderObject;
    public MonoBehaviour scriptToDisable;
    private bool isLookingAtGenerator = false;
    private bool isEPressed = false;
    [SerializeField] float sliderSpeedRate;
    [SerializeField] GameObject sprintAndReticle;
    public float maxInteractionDistance = 5f; // Maximum interaction distance
    [SerializeField] GeneratorController genControl;
    public bool generatorBroken;
    bool isFixingGenerator;
    [SerializeField] bool isLookingAtFurnace = false;
    [SerializeField] public bool furnaceBroken = false;
    [SerializeField] FurnaceController furnaceControl;
    bool isFixingFurnace;
    bool isLookingAtRadio = false;
    public bool radioPlaying = false;
    [SerializeField] RadioController radioControl;
    bool isFixingRadio;
    [SerializeField] float genFixSpeed;
    [SerializeField] float furnFixSpeed;
    [SerializeField] float radioFixSpeed;

    #endregion Variables and Objects

    void Awake()
    {
        sliderObject.SetActive(false);
        genControl = FindObjectOfType<GeneratorController>();
    }
    void Update()
    {
        #region Event Subscriptions
        if (genControl != null) { genControl.generatorBroken += OnGeneratorBroken; }
        if (furnaceControl != null) { furnaceControl.furnaceBroken += OnFurnaceBroken; }
        #endregion Event Subscriptions
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectToShow.SetActive(false);
            if (isLookingAtGenerator && generatorBroken == true)
            {
                isEPressed = true;
                sliderSpeedRate = genFixSpeed * 100;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingGenerator = true;
            }
            else if (isLookingAtFurnace && furnaceBroken == true)
            {
                isEPressed = true;
                sliderSpeedRate = furnFixSpeed * 100;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingFurnace = true;
            }
            else if (isLookingAtRadio && radioPlaying == true)
            {
                isEPressed = true;
                sliderSpeedRate = radioFixSpeed * 100;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingRadio = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
            scriptToDisable.enabled = true;
            sliderObject.SetActive(false);
        }
        // If E is held down, increment the slider value
        if (isEPressed) { slider.value += (sliderSpeedRate / 10) * Time.deltaTime; }
        else
        {
            slider.value = 0f;
            objectToShow.SetActive(true);
        }

        if (slider.value == 100f)
        {
            isEPressed = false;
            scriptToDisable.enabled = true;
            sliderObject.SetActive(false);
            if (isFixingGenerator)
            {
                genControl.ResetSlider();
                generatorBroken = false;
                isFixingGenerator = false;
            }
            else if (isFixingFurnace)
            {
                furnaceControl.ResetSlider();
                furnaceBroken = false;
                isFixingFurnace = false;
            }
            else if (isFixingRadio)
            {
                radioControl.ResetRadio();
                radioPlaying = false;
                isFixingRadio = false;
            }
            else
            {
                Debug.LogError("Nothing is broken");
            }
        }

        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(generatorTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtGenerator = true;
            }
            else if (hit.collider.CompareTag(furnaceTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtFurnace = true;
            }
            else if (hit.collider.CompareTag(radioTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtRadio = true;
            }
            else
            {
                isLookingAtFurnace = false;
                isLookingAtGenerator = false;
                isLookingAtRadio = false;
            }
        }

        //Enables the text if we're looking at the generator, and disables it if we're not
        if (!isEPressed )
        {
            if (generatorBroken == true && isLookingAtGenerator || furnaceBroken == true && isLookingAtFurnace || radioPlaying == true && isLookingAtRadio)
            {
                objectToShow.SetActive(true);
            }
            else { objectToShow.SetActive(false); }
        }
    }
    void OnGeneratorBroken()
    {
        generatorBroken = true;
        Debug.Log("Generator is broken! Do something here...");
    }
    void OnFurnaceBroken()
    {
        furnaceBroken = true;
        Debug.Log("Furnace Broken");
    }
}
