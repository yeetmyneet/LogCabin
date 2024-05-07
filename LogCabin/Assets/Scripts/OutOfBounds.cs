using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Canvas blackScreen;
    [SerializeField] Canvas crosshair;
    [SerializeField] AudioSource gunSource;
    [SerializeField] AudioClip distantGunshot;
    [SerializeField] FirstPersonController FPC;
    [SerializeField] FootstepSound FS;
    [SerializeField] FlashlightToggle FT;
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            blackScreen.enabled = true;
            crosshair.enabled = false;
            FPC.enabled = false;
            FS.enabled = false;
            FT.enabled = false;
            gunSource.PlayOneShot(distantGunshot);
            StartCoroutine(LoadNextLevel1());
            Debug.Log("over");

            IEnumerator LoadNextLevel1()
            {
                yield return new WaitForSecondsRealtime(levelLoadDelay);
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("DeathScreen");
            }
        }
    }
}
