using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector3 targetPosition;
    public int deerHealth = 3;
    public GameManager gameManager;
    public DeerMovement deerMovement;
    [SerializeField] AudioClip hitSound;
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
            Debug.Log("deer died");
        }
       else
        {
            deerHealth--;
            hitSource.PlayOneShot(hitSound);
            Debug.Log("deer took damage");
        }
    }

    public void Dissolve()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null) { rb.constraints = RigidbodyConstraints.FreezeAll; }
        else { Debug.LogError("no Rigidbody attached to Enemy"); }
        // Spawn the prefab on the gameObject
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            Debug.Log("spawned smoke on deer");
        }
        else { Debug.LogError("no prefab attached to Enemy"); }
        StartCoroutine(DestroyAfterDelay(0.5f));
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        if (prefabToSpawn != null) { Destroy(prefabToSpawn); }
    }
}
