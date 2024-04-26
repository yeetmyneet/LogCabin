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
        //if the player is too far away
        else
        {
            agent.destination = home;
        }
    }
}
