using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Dissolve()
    {
        // Lock the gameObject in place
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null) { rb.constraints = RigidbodyConstraints.FreezeAll; }
        else
        { Debug.Log("no Rigidbody attached to Enemy"); }
        // Spawn the prefab on the gameObject
        if (prefabToSpawn != null) { Instantiate(prefabToSpawn, transform.position, Quaternion.identity); }
        else { Debug.Log("no prefab attached to Enemy"); }
        // Wait for 1 second
        StartCoroutine(DestroyAfterDelay(1f));
    }
    #region Destroy After Delay
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy both the prefab and the gameObject
        Destroy(gameObject);
        if (prefabToSpawn != null)
        {
            Destroy(prefabToSpawn);
        }
    }
    #endregion Destroy After Delay
}
