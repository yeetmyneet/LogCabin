using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas creditsCanvas;

    void Start()
    {
        // Ensure that the Credits Canvas is initially disabled
        creditsCanvas.gameObject.SetActive(false);
    }

    // Function to disable Main Canvas and show Credits Canvas
    public void ShowCredits()
    {
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);
    }

    // Function to disable Credits Canvas and show Main Canvas
    public void ShowMain()
    {
        creditsCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
