using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractingScript : MonoBehaviour
{
    #region Variables and Objects 

    string generatorTag = "Generator";
    string furnaceTag = "Furnace";
    public GameObject objectToShow;
    public Slider slider;
    public GameObject sliderObject;
    public MonoBehaviour scriptToDisable;
    private bool isLookingAtGenerator = false;
    private bool isEPressed = false;
    [SerializeField] float sliderSpeedRate = 1f;
    [SerializeField] GameObject sprintAndReticle;
    public float maxInteractionDistance = 5f; // Maximum interaction distance
    [SerializeField] GeneratorController genControl;
    public bool generatorBroken;
    [SerializeField] bool isLookingAtFurnace = false;
    [SerializeField] bool furnaceBroken = false;
    [SerializeField] FurnaceController furnaceControl;
    bool isFixingGenerator;
    bool isFixingFurnace;

    #endregion Variables and Objects

    void Awake()
    {
        sliderObject.SetActive(false);
        genControl = FindObjectOfType<GeneratorController>();
    }
    void Update()
    {
        if (genControl != null)
        {
            genControl.generatorBroken += OnGeneratorBroken;
        }
        if (furnaceControl != null)
        {
            furnaceControl.furnaceBroken += OnFurnaceBroken;
        }
        // Check if E is pressed and is looking at the generator
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isLookingAtGenerator && generatorBroken == true)
            {
                isEPressed = true;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingGenerator = true;
            }
            else if (isLookingAtFurnace && furnaceBroken == true)
            {
                isEPressed = true;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingFurnace = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
            scriptToDisable.enabled = true;
            sliderObject.SetActive(false);
        }
        // If E is held down, increment the slider value
        if (isEPressed) { slider.value += sliderSpeedRate / 100; }
        else { slider.value = 0f; }
        if (slider.value == 100f)
        {
            isEPressed = false;
            scriptToDisable.enabled = true;
            sliderObject.SetActive(false);
            if (isFixingGenerator && generatorBroken == true)
            {
                genControl.ResetSlider();
                generatorBroken = false;
                isFixingGenerator = false;
            }
            else if (isFixingFurnace && furnaceBroken == true)
            {
                furnaceControl.ResetSlider();
                furnaceBroken = false;
                isFixingGenerator = false;
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
            else
            {
                isLookingAtFurnace = false;
                isLookingAtGenerator = false;
            }
        }

        //Enables the text if we're looking at the generator, and disables it if we're not
        if (!isEPressed )
        {
            if (generatorBroken == true && isLookingAtGenerator || furnaceBroken == true && isLookingAtFurnace)
            {
                objectToShow.SetActive(true);
            }
            else
            {
                objectToShow.SetActive(false);
            }
        }
    }
    void OnGeneratorBroken()
    {
        generatorBroken = true;
        Debug.Log("Generator is broken! Do something here...");
    }
    public void generatorFixed()
    {
        generatorBroken = false;
    }
    void OnFurnaceBroken()
    {
        furnaceBroken = true;
        Debug.Log("Furnace is broken!");
    }
    public void furnaceFixed()
    {
        furnaceBroken = false;
    }
}
