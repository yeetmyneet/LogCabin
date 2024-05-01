using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    public AudioClip manScream;
    public AudioClip bloodSound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    public MonoBehaviour[] playerScripts;
    public GameObject[] controllers;
    public Image fadeImage;
    public float fadeSpeed = 1.0f;
    public FadeOutDeath fadeScript;
    public bool lockPosition = false;
    public DeerMovement deerChase;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy!");
            Rigidbody rb = GetComponent<Rigidbody>();
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
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found. Cannot lock position.");
            }
            deerChase.isDead = true;
            fadeScript.StartCoroutine(fadeScript.FadeToBlackAndLoadScene());
        }
    }
}
