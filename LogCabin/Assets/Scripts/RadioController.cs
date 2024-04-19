using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip musicClip; // Assign your music clip in the Unity Editor
    private AudioSource audioSource;
    private bool isPlaying = false;
    [SerializeField] InteractingScript interactScript;
    [SerializeField] float checkInterval;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CheckForChance", 0f, checkInterval );
    }

    void CheckForChance()
    {
        if (!isPlaying && Random.Range(1, 11) == 1) // Roll a 1 in 10 chance
        {
            PlayMusic();
            CancelInvoke("CheckForChance"); // Stop checking for chance
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
        interactScript.BreakRadio();
        Debug.Log("Playing song from Radio");
    }

    public void ResetRadio()
    {
        if (isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
            InvokeRepeating("CheckForChance", 0f, 5f); // Start checking for chance again
        }
    }
}
