using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractingScript : MonoBehaviour
{
    #region Variables and Objects 

    [SerializeField] string generatorTag = "Generator";
    [SerializeField] string furnaceTag = "Furnace";
    [SerializeField] string radioTag = "Radio";
    [SerializeField] string truckTag = "Truck";
    [SerializeField] string gasTag = "Gas Can";
    [SerializeField] string truckExitTag = "TruckExit";
    public GameObject objectToShow;
    public Slider slider;
    public GameObject sliderObject;
    public MonoBehaviour scriptToDisable;
    private bool isLookingAtGenerator = false;
    private bool isEPressed = false;
    [SerializeField] float sliderSpeedRate;
    [SerializeField] GameObject sprintAndReticle;
    public float maxInteractionDistance = 5f;
    [SerializeField] GeneratorController genControl;
    [SerializeField] ObjectiveUI objectiveUI;
    [SerializeField] TextMeshProUGUI nextObj;
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
    [SerializeField] bool isLookingAtTruck = false;
    [SerializeField] public bool truckOutOfGas = false;
    [SerializeField] bool isFixingTruck;
    [SerializeField] float truckFixSpeed = 30f;
    [SerializeField] TruckController truckControl;
    [SerializeField] bool isLookingAtGas;
    [SerializeField] bool hasGasCan = false;
    [SerializeField] bool isGettingGas;
    [SerializeField] bool gasCanShowing = true;
    [SerializeField] float gasPickupSpeed = 6f;
    [SerializeField] GameObject gasCanObject;
    [SerializeField] bool isLookingAtTruckDoor = false;
    [SerializeField] bool isEnteringTruck = false;
    [SerializeField] float truckEnterSpeed = 30f;
    [SerializeField] PlayerCollision playerCollision;
    [SerializeField] Collider leave;
    public int cabinLevel;
    public int gasStationLevel;
    public int huntingGroundsLevel;
    #endregion Variables and Objects
    void Awake()
    {
        sliderObject.SetActive(false);
        genControl = FindObjectOfType<GeneratorController>();

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == cabinLevel)
        {
            nextObj.text = "-Don't make a Sound";
        }
        if (currentLevel == gasStationLevel)
        {
            nextObj.text = "-Pickup your Mobile Order";
        }
        if (currentLevel == huntingGroundsLevel)
        {
            nextObj.text = "-Hunt the Deer Down";
        }
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
            else if (isLookingAtTruck && truckOutOfGas == true && hasGasCan == true)
            {
                isEPressed = true;
                sliderSpeedRate = truckFixSpeed * 100;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isFixingTruck = true;
            }
            else if (isLookingAtGas && gasCanShowing)
            {
                isEPressed = true;
                sliderSpeedRate = gasPickupSpeed * 100;
                Debug.Log("picking up gas at speed of: " + sliderSpeedRate);
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                Debug.Log("enabled slider and disabled scripts");
                isGettingGas = true;
            }
            else if (isLookingAtTruckDoor && !truckOutOfGas)
            {
                isEPressed = true;
                sliderSpeedRate = truckEnterSpeed * 100;
                scriptToDisable.enabled = false;
                sliderObject.SetActive(true);
                isEnteringTruck = true;
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
            else if (isFixingTruck && hasGasCan)
            {
                truckControl.FixTruck();
                truckOutOfGas = false;
                isFixingTruck = false;
            }
            else if (isGettingGas)
            {
                gasCanObject.SetActive(false);
                Debug.Log("got gas can");
                objectiveUI.Objective("Load your truck up");
                nextObj.text = "-Explore or Leave";
                gasCanShowing = false;
                isGettingGas = false;
                hasGasCan = true;
            }
            if (isEnteringTruck)
            {
                leave.enabled = true;
                Debug.Log("player is exiting game");
                isEnteringTruck = false;
            }
            //else { Debug.LogError("Nothing is broken"); }
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
            else if (hit.collider.CompareTag(truckTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtTruck = true;
                Debug.Log("looking at truck");
            }
            else if (hit.collider.CompareTag(gasTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtGas = true;
                Debug.Log("looking at gas");
                objectiveUI.Objective("Pickup your Mobile Order");
                nextObj.text = "-Load your truck up";
            }
            else if (hit.collider.CompareTag(truckExitTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                isLookingAtTruckDoor = true;
                Debug.Log("looking at truck door");
            }
            else
            {
                isLookingAtFurnace = false;
                isLookingAtGenerator = false;
                isLookingAtRadio = false;
                isLookingAtTruck = false;
                isLookingAtGas = false;
                isLookingAtTruckDoor = false;
            }
        }
        if (!isEPressed )
        {
            if (generatorBroken == true && isLookingAtGenerator || furnaceBroken == true && isLookingAtFurnace || radioPlaying == true && isLookingAtRadio || isLookingAtTruck && truckOutOfGas == true && hasGasCan == true || isLookingAtGas && gasCanShowing || isLookingAtTruckDoor && !truckOutOfGas)
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
