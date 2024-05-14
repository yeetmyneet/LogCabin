using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Inspector References
    public GameObject prefabToSpawn;
    private float startTime;
    public GameObject countdownTimer;
    public float fadeOutDelay;
    public string endlessModeTrigger = "EndlessTrigger";
    public GameObject door;
    public MonoBehaviour[] playerScripts;
    public GameObject[] controllers;
    public GameObject doorBlocker;
    public GameObject window;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public AudioClip doorSound;
    public AudioClip windowSound;
    public AudioClip deerChaseMusic;
    public AudioClip doorOpenSound;
    public MonoBehaviour[] scriptsToDisable;
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioSource audioSource3;
    [SerializeField] PlayerCollision playerCollision;
    public FadeOutDeath fadeScript;
    public DeerMovement deerMovement;
    bool spawnedDeer = false;
    [SerializeField] ObjectiveUI objectiveUI;
    public int cabinBuildIndex;
    public int gasStationBuildIndex;
    public int huntingGroundsIndex;
    #endregion Inspector References
    void Awake()
    {
        // Get the current scene's build index
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene's build index matches the target build index
        if (currentBuildIndex == cabinBuildIndex)
        {
            if (PlayerPrefs.GetInt(endlessModeTrigger, 0) == 1)
            {
                StartStopwatch();
                countdownTimer.SetActive(false);
                objectiveUI.Objective("Survive!");
            }
            else
            {
                objectiveUI.Objective("Don't make a Sound");
            }
        }
        if (currentBuildIndex == gasStationBuildIndex)
        {
            objectiveUI.Objective("Find your Mobile Order");
        }
        if(currentBuildIndex == huntingGroundsIndex)
        {
            objectiveUI.Objective("Hunt the Deer");
        }
    }
    public void SpawnPrefabAtTransform1(int attackType)
    {
        if (prefabToSpawn != null && spawnPoint1 != null && !spawnedDeer && attackType == 1)
        {
            Instantiate(prefabToSpawn, spawnPoint1.position, spawnPoint1.rotation);
            Debug.Log("spawned deer at spawnpoint1");
            door.SetActive(false);
            doorBlocker.SetActive(true);
            Debug.Log("broke door");
            objectiveUI.Objective("Accept your fate");
            audioSource1.clip = doorSound;
            audioSource1.Play();
            audioSource2.clip = deerChaseMusic;
            audioSource2.Play();
            spawnedDeer = true;
            Debug.Log("set spawnedDeer to true");
        }
        else if (prefabToSpawn != null && spawnPoint2 != null && !spawnedDeer && attackType == 2)
        {
            Instantiate(prefabToSpawn, spawnPoint2.position, spawnPoint2.rotation);
            door.SetActive(false);
            doorBlocker.SetActive(true);
            Debug.Log("broke door");
            audioSource1.clip = doorSound;
            audioSource1.Play();
            audioSource2.clip = deerChaseMusic;
            audioSource2.Play();
            spawnedDeer = true;
            Debug.Log("set spawnedDeer to true");
        }
        else if (prefabToSpawn != null && spawnPoint3 != null && !spawnedDeer && attackType == 3)
        {
            Instantiate(prefabToSpawn, spawnPoint3.position, spawnPoint3.rotation);
            door.SetActive(false);
            doorBlocker.SetActive(true);
            Debug.Log("broke door");
            audioSource1.clip = doorSound;
            audioSource1.Play();
            audioSource2.clip = deerChaseMusic;
            audioSource2.Play();
            spawnedDeer = true;
            Debug.Log("set spawnedDeer to true");
        }
    }
    public void EndTimer()
    {
        door.SetActive(false);
        doorBlocker.SetActive(false);
        foreach (MonoBehaviour scripts in scriptsToDisable)
        {
            scripts.enabled = false;
        }
        audioSource1.clip = doorOpenSound;
        audioSource1.Play();
        objectiveUI.Objective("Escape The House!");
    }
    public void StartStopwatch()
    {
        startTime = Time.time;
        Debug.Log("Stopwatch started.");
    }

    public void StopStopwatchAndSaveTime()
    {
        float elapsedTime = Time.time - startTime;
        SaveTime(elapsedTime);
        Debug.Log("Stopwatch stopped. Elapsed time: " + elapsedTime + " seconds.");
    }

    public void SaveTime(float time)
    {
        PlayerPrefs.SetFloat("StopwatchTime", time);
        PlayerPrefs.Save();
        Debug.Log("Time saved: " + time + " seconds.");
    }
    void OnApplicationQuit()
    {
        // Delete the PlayerPrefs value when the game exits
        PlayerPrefs.DeleteKey(endlessModeTrigger);
        Debug.Log("Value endlessModeTrigger deleted from PlayerPrefs on application quit.");
    }
    public void BeatGame()
    {
        DisableScriptsAndControllers();
        fadeScript.StartCoroutine(fadeScript.LoadWinScreen(1f));
    }
    public void DisableScriptsAndControllers()
    {
        foreach (MonoBehaviour scripts in playerScripts)
        {
            scripts.enabled = false;
        }
        foreach (GameObject obj in controllers)
        {
            obj.SetActive(false);
        }
    }
}
