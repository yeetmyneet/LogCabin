using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject door;
    public GameObject window;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public AudioClip doorSound;
    public AudioClip windowSound;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioSource audioSource3;
    public DeerMovement deerMovement;
    bool spawnedDeer = false;
    public void SpawnPrefabAtTransform1(int attackType)
    {
        if (prefabToSpawn != null && spawnPoint1 != null && !spawnedDeer && attackType == 1)
        {
            Instantiate(prefabToSpawn, spawnPoint1.position, spawnPoint1.rotation);
            Debug.Log("spawned deer at spawnpoint1");
            door.SetActive(false);
            Debug.Log("broke door");
            audioSource1.clip = doorSound;
            audioSource1.Play();
            spawnedDeer = true;
            Debug.Log("set spawnedDeer to true");
        }
        else if (prefabToSpawn != null && spawnPoint2 != null && !spawnedDeer && attackType == 2)
        {
            Instantiate(prefabToSpawn, spawnPoint2.position, spawnPoint2.rotation);
            window.SetActive(false);
            Debug.Log("spawned at spawnpoint2");
            spawnedDeer = true;
        }
        else if (prefabToSpawn != null && spawnPoint3 != null && !spawnedDeer && attackType == 3)
        {
            Instantiate(prefabToSpawn, spawnPoint3.position, spawnPoint3.rotation);
            window.SetActive(false);
            audioSource3.clip = windowSound;
            audioSource3.Play();
            spawnedDeer = true;
        }
    }
}
