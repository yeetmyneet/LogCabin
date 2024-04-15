using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas creditsCanvas;

    void Start()
    {
        creditsCanvas.gameObject.SetActive(false);
    }
    public void ShowCredits()
    {
        mainCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);
    }
    public void ShowMain()
    {
        creditsCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
