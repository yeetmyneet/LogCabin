using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip manScream;
    public AudioClip bloodSound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    public MonoBehaviour[] playerScripts;
    public GameObject[] controllers;

    private void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy!");
            foreach (MonoBehaviour scripts in playerScripts)
            {
                scripts.enabled = false;
            }
            foreach (GameObject obj in controllers)
            {
                obj.SetActive(false);
            }
            audioSource1.clip = manScream;
            audioSource2.clip = bloodSound;
            audioSource1.Play();
            audioSource2.Play();
        }
    }
}
