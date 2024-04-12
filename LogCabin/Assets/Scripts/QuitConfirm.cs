using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirm : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas confirmCanvas;

    void Start()
    {
        
        confirmCanvas.gameObject.SetActive(false);
    }

   
    public void ShowConfirm()
    {
        mainCanvas.gameObject.SetActive(false);
        confirmCanvas.gameObject.SetActive(true);
    }

   
    public void ShowMain()
    {
        confirmCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
