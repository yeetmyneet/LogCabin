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
        else { Debug.LogError("no Rigidbody attached to Enemy"); }
        // Spawn the prefab on the gameObject
        if (prefabToSpawn != null) { Instantiate(prefabToSpawn, transform.position, Quaternion.identity); }
        else { Debug.LogError("no prefab attached to Enemy"); }
        StartCoroutine(DestroyAfterDelay(1f));
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        if (prefabToSpawn != null) { Destroy(prefabToSpawn); }
    }
}
