using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DeerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance = 10;
    NavMeshAgent agent;
    Vector3 home;

    void Start()
    {
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 moveDir = player.transform.position - transform.position;
        //if the player is close
        if (moveDir.magnitude < chaseDistance)
        {
            //chase the player
            agent.destination = player.transform.position;
        }
        if (moveDir != Vector3.zero)
        {
            // Calculate the rotation to look towards the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);

            // Add 90 degrees to the rotation
            Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);

            // Combine the target rotation with the additional rotation
            Quaternion finalRotation = targetRotation * additionalRotation;

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 10f);
        }
        //if the player is too far away
        else
        {
            agent.destination = home;
        }
    }
}
