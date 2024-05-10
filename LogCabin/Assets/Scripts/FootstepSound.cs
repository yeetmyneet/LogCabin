using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    #region Inspector References
    public float stepRate = 0.5f;
    public string woodSurfaceTag = "Wood Floor";
    public string snowSurfaceTag = "Snow Floor";
    public string concreteSurfaceTag = "Concrete Floor";
    public float stepCooldown;
    public AudioSource source;
    public AudioClip woodFootstep;
    public AudioClip snowFootstep;
    public AudioClip concreteFootstep;
#endregion Inspector References
    private void Update()
    {
        stepCooldown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCooldown < 0f)
        {
            source.pitch = 1f + Random.Range(-0.2f, 0.2f);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.collider.CompareTag(woodSurfaceTag))
                {
                    source.PlayOneShot(woodFootstep, 0.8f);
                }
                if (hit.collider.CompareTag(snowSurfaceTag))
                {
                    source.PlayOneShot(snowFootstep, 0.8f);
                }
                if (hit.collider.CompareTag(concreteSurfaceTag))
                {
                    source.PlayOneShot(concreteFootstep, 0.8f);
                }
            }
            stepCooldown = stepRate;
        }
    }
}
