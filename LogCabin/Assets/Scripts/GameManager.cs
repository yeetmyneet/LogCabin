using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    public void SpawnPrefabAtTransform1()
    {
        if (prefabToSpawn != null && spawnPoint != null) { Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation); }
        else { Debug.LogError("Prefab or spawn point is not assigned."); }
    }
}
