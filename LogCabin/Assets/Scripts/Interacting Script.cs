using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractingScript : MonoBehaviour
{
    #region Variables and Objects 

    public string generatorTag = "Generator";
    public GameObject objectToShow;
    public Slider slider;
    public GameObject sliderObject;
    public MonoBehaviour scriptToDisable;
    private bool isLookingAtGenerator = false;
    private bool isEPressed = false;
    [SerializeField] float sliderSpeedRate = 1f;
    [SerializeField] GameObject sprintAndReticle;
    public float maxInteractionDistance = 5f; // Maximum interaction distance

    #endregion

    void Awake()
    {
        sliderObject.SetActive(false);
    }
    void Update()
    {
        // Check if E is pressed
        if (Input.GetKeyDown(KeyCode.E) && isLookingAtGenerator)
        {
            isEPressed = true;
            // Disable the specified script
            scriptToDisable.enabled = false;
            // Enable the slider object
            sliderObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
            // Enable the specified script
            scriptToDisable.enabled = true;
            // Disable the slider object
            sliderObject.SetActive(false);
        }
        // If E is held down, increment the slider value and update the visual representation
        if (isEPressed)
        {
            slider.value += sliderSpeedRate / 100;
        }
        else
        {
            slider.value = 0f;
        }
        // Cast a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(generatorTag) && Vector3.Distance(transform.position, hit.transform.position) <= maxInteractionDistance)
            {
                // Player is looking at an object with the specified tag
                isLookingAtGenerator = true;
            }
            else
            {
                // Player is not looking at an object with the specified tag
                isLookingAtGenerator = false;
            }
        }
        else
        {
            // Player is not looking at anything
            isLookingAtGenerator = false;
        }

        if (!isEPressed && isLookingAtGenerator)
        {
            objectToShow.SetActive(true);
        }
        else
        {
            objectToShow.SetActive(false);
        }
    }
}
