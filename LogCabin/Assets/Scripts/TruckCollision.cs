using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCollision : MonoBehaviour
{
    [SerializeField] FadeOutDeath fadeoutScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fadeoutScript.LoadWinScreen();
        }
    }
}
