using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Canvas blackScreen;
    [SerializeField] Canvas crosshair;
    [SerializeField] FirstPersonController FPC;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            blackScreen.enabled = true;
            crosshair.enabled = false;
            FPC.enabled = false;
            Debug.Log("over");
        }
    }
}
