using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DeerMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float chaseDistance = 10;
    NavMeshAgent agent;
    Vector3 home;

    void Start()
    {
        home = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 moveDir = player.transform.position - transform.position;
        //if the player is close
        if (moveDir.magnitude < chaseDistance) { agent.destination = player.transform.position; }
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            // Add 90 degrees to the rotation
            Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);
            Quaternion finalRotation = targetRotation * additionalRotation;
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 10f);
        }
        else { agent.destination = home; }
    }
}
