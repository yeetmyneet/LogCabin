using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public FadeOutDeath fadeScript;
    public AudioSource truckSounds;
    public AudioClip truckStart;
    [SerializeField] bool isCabin = false;
    [SerializeField] bool isGasStation = false;
    [SerializeField] float levelLoadDelay = 7f;
    [SerializeField] FirstPersonController MOVE;
    [SerializeField] FootstepSound stepStomp;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TruckExit")
        {
            fadeScript.StartCoroutine(fadeScript.FadeToBlack());
            StartCoroutine(LoadNextLevel());
            truckSounds.PlayOneShot(truckStart);
            MOVE.enabled = false;
            stepStomp.enabled = false;
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (isCabin == true)
        {
            SceneManager.LoadScene("GasStation");
        }
        if (isGasStation == true)
        {
            SceneManager.LoadScene("HuntingGrounds");
        }
    }


}
