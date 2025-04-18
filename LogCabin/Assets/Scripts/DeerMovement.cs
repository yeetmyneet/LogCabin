using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DeerMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float forwardForce = 5f;
    public GameObject window;
    private GameObject player;
    [SerializeField] float chaseDistance = 10;
    NavMeshAgent agent;
    Vector3 home;
    public bool isDead = false;
    public bool deerIsAlive = true;
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
        if (moveDir.magnitude < chaseDistance && isDead == false && deerIsAlive == true)
        {
            agent.destination = player.transform.position;
            GetComponent<Animator>().SetTrigger("Chase");
        }
        else
        {
            Debug.Log("player is alive: " + isDead + ", deer is dead: " + deerIsAlive);
        }
        if (moveDir != Vector3.zero)
        {
            if (isDead == false && deerIsAlive == true)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                // Add 90 degrees to the rotation
                Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);
                Quaternion finalRotation = targetRotation * additionalRotation;
                // Smoothly rotate towards the target rotation
                transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * 10f);
            }
            else
            {
                Debug.Log("player is alive: " + isDead + ", deer is dead: " + deerIsAlive);
            }
        }
        else
        {
            agent.destination = home;
        }
        if (transform.position == home)
        {
            GetComponent<Animator>().SetTrigger("Home");
        }
    }
}
