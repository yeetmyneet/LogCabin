using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeerHealth : MonoBehaviour
{
    [SerializeField] Animator deerAnim;
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] DeerMovement movement;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad5))
        {
            deerAnim.enabled = false;
            Agent.enabled = false;
            movement.enabled = false;
        }
    }
}
