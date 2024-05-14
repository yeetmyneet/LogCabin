using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject muzzleFlash;
    public EnemyController enemyController;
    [SerializeField] AudioClip gunshot;
    [SerializeField] Animator gunAnim;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
    }
}