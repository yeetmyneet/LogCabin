using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public PlayerCollision collisionScript;
    public Vector3 targetPosition;
    public float deerHealth = 3f;
    public GameManager gameManager;
    public float deerDamage = 1f;
    public DeerMovement deerMovement;
    [SerializeField] Animator deeranim;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource hitSource;

    public void TeleportToPosition() { transform.position = targetPosition; }

    public void TakeDamage()
    {
       if (deerHealth <= 0)
        {
            deerMovement.isDead = true;
            hitSource.PlayOneShot(deathSound);
            Dissolve();
            gameManager.BeatGame();
            hitSource.pitch = 1;
            hitSource.PlayOneShot(deathSound);
            Debug.Log("deer died");
        }
       else
        {
            hitSource.PlayOneShot(hurtSound);
            hitSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            deerHealth -= deerDamage;
            hitSource.PlayOneShot(hitSound);
            Debug.Log("deer took damage");
            Debug.Log("deer health: " + deerHealth);
        }
    }

    public void Dissolve()
    {
        collisionScript.deerDead = true;
        deeranim.SetTrigger("Idle");
        Debug.Log("Set collisonscript.deerdead to true");
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            Debug.Log("deer rigidbody frozen.");
        }
        else { Debug.LogError("no Rigidbody attached to Enemy"); }
        // Spawn the prefab on the gameObject
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            Debug.Log("spawned smoke on deer");
        }
        else { Debug.LogError("no prefab attached to Enemy"); }
        StartCoroutine(DestroyAfterDelay(1f));
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DestroyImmediate(gameObject, true);
        Debug.Log("Destroyed deer after delay");
        if (prefabToSpawn != null) { Destroy(prefabToSpawn); }
    }
}
