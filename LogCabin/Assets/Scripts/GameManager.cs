using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject door;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public AudioClip spawnSound;
    [SerializeField] AudioSource audioSource;
    bool genAttack = false;
    bool furnAttack = false;
    bool radioAttack = false;

    public void SpawnPrefabAtTransform1()
    {
        if (prefabToSpawn != null && spawnPoint1 != null && !furnAttack && !radioAttack)
        {
            Instantiate(prefabToSpawn, spawnPoint1.position, spawnPoint1.rotation);
            door.SetActive(false);
            audioSource.clip = spawnSound;
            audioSource.Play();
            genAttack = true;
        }
        else if (prefabToSpawn != null && spawnPoint2 != null && !genAttack && !radioAttack)
        {
            Instantiate(prefabToSpawn, spawnPoint2.position, spawnPoint2.rotation);
            door.SetActive(false);
            audioSource.clip = spawnSound;
            audioSource.Play();
            furnAttack = true;
        }
        else if (prefabToSpawn != null && spawnPoint3 != null && !furnAttack && !genAttack)
        {
            Instantiate(prefabToSpawn, spawnPoint3.position, spawnPoint3.rotation);
            door.SetActive(false);
            audioSource.clip = spawnSound;
            audioSource.Play();
            radioAttack = true;
        }
    }
}
