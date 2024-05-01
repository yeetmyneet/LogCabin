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
    public AudioClip doorSound;
    public AudioClip windowSound;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioSource audioSource3;
    bool genAttack = false;
    bool furnAttack = false;
    bool radioAttack = false;
    public DeerMovement deerMovement;
    bool spawnedDeer = false;

    public void SpawnPrefabAtTransform1()
    {
        if (prefabToSpawn != null && spawnPoint1 != null && !furnAttack && !radioAttack && !spawnedDeer || Input.GetKeyDown(KeyCode.Backspace) && !spawnedDeer)
        {
            Instantiate(prefabToSpawn, spawnPoint1.position, spawnPoint1.rotation);
            Debug.Log("spawned deer");
            door.SetActive(false);
            Debug.Log("broke door");
            audioSource1.clip = doorSound;
            audioSource1.Play();
            genAttack = true;
            spawnedDeer = true;
            Debug.Log("set spawnedDeer to true");
        }
        else if (prefabToSpawn != null && spawnPoint2 != null && !genAttack && !radioAttack && !spawnedDeer || Input.GetKeyDown(KeyCode.Equals))
        {
            Instantiate(prefabToSpawn, spawnPoint2.position, spawnPoint2.rotation);
            deerMovement.JumpThroughWindow();
            furnAttack = true;
            spawnedDeer = true;
        }
        else if (prefabToSpawn != null && spawnPoint3 != null && !furnAttack && !genAttack && !spawnedDeer)
        {
            Instantiate(prefabToSpawn, spawnPoint3.position, spawnPoint3.rotation);
            door.SetActive(false);
            audioSource3.clip = windowSound;
            audioSource3.Play();
            radioAttack = true;
            spawnedDeer = true;
        }
    }
}
