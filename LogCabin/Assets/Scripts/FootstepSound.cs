using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepsSound;

    [SerializeField] AudioClip wood;
    [SerializeField] AudioClip snow;

    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;

    private void Footstep()
    {
        if(Physics.Raycast(RayStart.position, RayStart.transform.up * -1, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("Wood Floor"))
            {
                PlayFootstepSoundL()
            }
        }
    }
}
