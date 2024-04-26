using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collider belongs to an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Do something when collided with an enemy
            Debug.Log("Player collided with an enemy!");
            
        }
    }
}
