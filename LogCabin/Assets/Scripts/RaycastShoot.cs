using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject muzzleFlash;
    public GameObject impact;
    public EnemyController enemyController;
    public float distance = 1f; 
    public float duration = 1f;
    public float rotateAngle = 0f;
    public float rotateDuration = 1f;
    public float cooldownDuration = 1.32f;
    [SerializeField] Animator gunAnim;
    [SerializeField] AudioSource shotgun;
    [SerializeField] AudioClip gunshot;
    [SerializeField] AudioClip triggerPull;
    [SerializeField] AudioClip pump;
    [SerializeField] Light flash;
    private float lastUsedTime;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {  
            if (CanUse())
            {
                gunAnim.SetTrigger("shoot");
                Debug.Log("shoot trigger for animator");
                shotgun.PlayOneShot(triggerPull);
                shotgun.PlayOneShot(gunshot);
                shotgun.PlayOneShot(pump);
                MarkUsed();
                StartCoroutine(flashDuration(0.1f));
                originalLocalPosition = transform.localPosition;
                originalLocalRotation = transform.localRotation;
                StartCoroutine(RotateAndReturn());
                StartCoroutine(MoveBackAndForth());
                if (muzzleFlash != null)
                {
                    Instantiate(muzzleFlash, muzzle.position, Quaternion.identity); ;
                }

                RaycastHit hit;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.name);
                        if (hit.collider.gameObject.tag == "Enemy")
                        {
                            enemyController.TakeDamage();
                            Debug.Log("Enemy Took Damage");
                        }
                        Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }
            }
            else
            {
                Debug.Log("cooldown still present");
                shotgun.PlayOneShot(triggerPull);
            }
        }
    }
    public bool CanUse()
    {
        // Check if enough time has passed since the last usage
        return Time.time - lastUsedTime >= cooldownDuration;
    }
    public void MarkUsed()
    {
        lastUsedTime = Time.time;
        gunAnim.SetTrigger("pumpOver");
    }
    IEnumerator flashDuration(float duration)
    {
        flash.enabled = true;

        yield return new WaitForSeconds(duration);

        flash.enabled = false;
    }

    IEnumerator MoveBackAndForth()
    {
        // Move back on the Z axis
        yield return MoveOverSeconds(new Vector3(originalLocalPosition.x, originalLocalPosition.y, originalLocalPosition.z - distance), duration);
        // Return to original local position
        yield return MoveOverSeconds(originalLocalPosition, duration);
    }

    IEnumerator MoveOverSeconds(Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.localPosition;
        while (elapsedTime < seconds)
        {
            transform.localPosition = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = end;
    }

    IEnumerator RotateAndReturn()
    {
        // Rotate around the X axis
        yield return RotateOverSeconds(Vector3.right, rotateAngle, rotateDuration);
        // Return to original local rotation
        yield return RotateOverSeconds(Vector3.right, -rotateAngle, rotateDuration);
    }

    IEnumerator RotateOverSeconds(Vector3 axis, float speed, float seconds)
    {
        float elapsedTime = 0;
        Quaternion startingRot = transform.localRotation;
        Quaternion endRotation = startingRot * Quaternion.Euler(axis * speed * seconds);

        while (elapsedTime < seconds)
        {
            transform.localRotation = Quaternion.Lerp(startingRot, endRotation, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localRotation = endRotation;
    }
}