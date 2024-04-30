using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Canvas blackScreen;
    [SerializeField] Canvas crosshair;
    [SerializeField] AudioSource gunSource;
    [SerializeField] AudioClip distantGunshot;
    [SerializeField] FirstPersonController FPC;
    [SerializeField] FootstepSound FS;
    [SerializeField] FlashlightToggle FT;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            blackScreen.enabled = true;
            crosshair.enabled = false;
            FPC.enabled = false;
            FS.enabled = false;
            FT.enabled = false;
            gunSource.PlayOneShot(distantGunshot);
            Debug.Log("over");
        }
    }
}
