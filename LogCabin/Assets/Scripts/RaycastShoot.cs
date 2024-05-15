using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject muzzleFlash;
    public GameObject impact;
    public EnemyController enemyController;
    [SerializeField] Animator gunAnim;
    [SerializeField] AudioSource shotgun;
    [SerializeField] AudioClip gunshot;
    [SerializeField] AudioClip triggerPull;
    [SerializeField] AudioClip pump;
    [SerializeField] Light flash;
    public float cooldownDuration = 1.32f;
    private float lastUsedTime;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {  
            if (CanUse())
            {
                gunAnim.SetTrigger("shoot");
                shotgun.PlayOneShot(triggerPull);
                shotgun.PlayOneShot(gunshot);
                shotgun.PlayOneShot(pump);
                MarkUsed();
                StartCoroutine(flashDuration(0.1f));
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
}