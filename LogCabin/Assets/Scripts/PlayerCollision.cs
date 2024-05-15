using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    #region Inspector References
    public AudioClip manScream;
    public bool deerDead = false;
    public AudioClip bloodSound;
    public AudioClip truckEnterSound;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;
    public MonoBehaviour[] playerScripts;
    public GameObject[] controllers;
    public Image fadeImage;
    public float fadeSpeed = 1.0f;
    public FadeOutDeath fadeScript;
    public bool lockPosition = false;
    public DeerMovement deerChase;
    public GameManager gameManager;
    #endregion Inspector References

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && deerDead == false)
        {
            Debug.Log("Player collided with an enemy!");
            Rigidbody rb = GetComponent<Rigidbody>();
            DisableScriptsAndControllers();
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
            gameManager.StopStopwatchAndSaveTime();
            fadeScript.StartCoroutine(fadeScript.FadeToBlackAndLoadScene());
        }
        if (collision.gameObject.CompareTag("TruckExit"))
        {
            ExitGame();
        }
        if (collision.gameObject.CompareTag("TruckTransition"))
        {
            fadeScript.SceneTransition();
        }
    }
    public void ExitGame()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        DisableScriptsAndControllers();
        audioSource3.clip = truckEnterSound;
        audioSource3.Play();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found. Cannot lock position.");
        }
        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        // Check if GameObject with tag "Enemy" is found
        if (enemyObject != null)
        {
            // Get the Rigidbody component attached to the enemy GameObject
            Rigidbody enemyRb = enemyObject.GetComponent<Rigidbody>();

            // Check if Rigidbody is not null
            if (enemyRb != null)
            {
                // Freeze position and rotation
                enemyRb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on object with tag 'Enemy'!");
            }
        }
        else
        {
            Debug.LogWarning("Object with tag 'Enemy' not found!");
        }
        fadeScript.StartCoroutine(fadeScript.LoadWinScreen(0f));
    }
    public void DisableScriptsAndControllers()
    {
        foreach (MonoBehaviour scripts in playerScripts)
        {
            scripts.enabled = false;
        }
        foreach (GameObject obj in controllers)
        {
            obj.SetActive(false);
        }
    }
}
