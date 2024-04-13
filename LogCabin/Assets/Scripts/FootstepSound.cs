using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCooldown;
    public AudioSource source;
    public AudioClip footstep;

    private void Update()
    {
        stepCooldown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCooldown < 0f)
        {
            source.pitch = 1f + Random.Range(-0.2f, 0.2f);
            source.PlayOneShot(footstep, 0.9f);
            stepCooldown = stepRate;
        }
    }
}
