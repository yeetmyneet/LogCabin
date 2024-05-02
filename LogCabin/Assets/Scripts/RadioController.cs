using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;
    private bool isPlaying = false;
    [SerializeField] InteractingScript interactScript;
    [SerializeField] float checkInterval;
    [SerializeField] bool tooLate = false;
    private float timeSinceReset;
    public float timeThreshold = 10f;
    [SerializeField] float brokenInterval;
    [SerializeField] float brokenTimer = 0f;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CheckForChance", 0f, checkInterval );
    }

    void Update()
    {
        if (isPlaying)
        {
            brokenTimer += Time.deltaTime;
            if (brokenTimer >= brokenInterval && isPlaying)
            {
                timeSinceReset++;
                Debug.Log("time since radio reset: " + timeSinceReset);
                brokenTimer = 0f;
            }
            if (timeSinceReset >= timeThreshold && !tooLate)
            {
                tooLate = true;
                gameManager.SpawnPrefabAtTransform1(3);
            }
        }
    }

    void CheckForChance()
    {
        if (!isPlaying && Random.Range(1, 11) == 1) // Roll a 1 in 10 chance
        {
            PlayMusic();
            CancelInvoke("CheckForChance");
        }
    }

    void PlayMusic()
    {
        if (musicClip != null)
        {
            isPlaying = true;
            audioSource.clip = musicClip;
            audioSource.Play();
        }
        interactScript.radioPlaying = true;
        Debug.Log("Playing song from Radio");
    }

    public void ResetRadio()
    {
        if (isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
            InvokeRepeating("CheckForChance", 0f, 5f);
            timeSinceReset = 0f;
        }
    }
}
