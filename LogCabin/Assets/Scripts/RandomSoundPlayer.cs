using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;
    private float rollInterval = 40f;
    private float nextRollTime = 0f;
    private int rollChance = 3; // 1 in 3 chance

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextRollTime = Time.time + rollInterval;
    }

    void Update()
    {
        if (Time.time >= nextRollTime)
        {
            nextRollTime = Time.time + rollInterval;

            // Roll for chance
            if (Random.Range(1, rollChance + 1) == 1)
            {
                PlaySound();
            }
        }
    }

    void PlaySound()
    {
        if (soundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
