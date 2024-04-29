using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirm : MonoBehaviour
{
    public Canvas[] mainCanvases;
    public Canvas confirmCanvas;

    void Start()
    {
        confirmCanvas.gameObject.SetActive(false);
    }

    void HideMainCanvases()
    {
        foreach (Canvas canvas in mainCanvases)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void ShowConfirm()
    {
        HideMainCanvases();
        confirmCanvas.gameObject.SetActive(true);
    }

    public void ShowMain()
    {
        confirmCanvas.gameObject.SetActive(false);
        foreach (Canvas canvas in mainCanvases)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
