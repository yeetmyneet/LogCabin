using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject muzzleFlash;
    public EnemyController enemyController;
    [SerializeField] AudioClip gunshot;
    public float cooldownDuration = 3f;
    private float lastUsedTime;
    [SerializeField] Animator gunAnim;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {  
            if (CanUse())
            {
                gunAnim.SetTrigger("shot");

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
                    }
                }
            }
            else
            {
                Debug.Log("cooldown still present");
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
    }
}