using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutDeath : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 2f;
    public float secondFadeSpeed = 4f;
    [SerializeField] CanvasGroup confirmCanvas;
    public AudioSource menuAudioSource;
    public AudioClip select;
    [SerializeField] private GraphicRaycaster raycaster;
    public CountdownTimer countdownTimer;
    [SerializeField] int nextSceneIndex;
    private void Awake()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);
    }

    public IEnumerator FadeToBlackAndLoadScene()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1.0f, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);

        SceneManager.LoadScene("DeathScreen");
    }
    public IEnumerator SendToMainMenu()
    {
        StartCoroutine(DisableAudioSources());
        countdownTimer.enabled = false;
        Debug.Log("PlayAudioClip");
        yield return null;
        
        StartCoroutine(DisableAudioSources());
        Debug.Log("disabled audio sources");
        Time.timeScale = 1;
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1.0f, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);

        SceneManager.LoadScene("MainMenu");
    }
    public void MainMenuSend()
    {
        StartCoroutine(SendToMainMenu());
    }
    IEnumerator DisableAudioSources()
    {
        //menuAudioSource.PlayOneShot(select, 1f);
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        raycaster.enabled = false;
        Debug.Log("confirmCanvas not interactable");
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.CompareTag("MenuAudio") || audioSource.CompareTag("Player"))
            {
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                audioSource.enabled = false;
            }
        }
        yield return new WaitForSeconds(0.5f);
    }
    public IEnumerator LoadWinScreen(float waitTime)
    {
        StartCoroutine(DisableAudioSources());
        yield return null;
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForSeconds(waitTime);
        fadeImage.CrossFadeAlpha(1.0f, secondFadeSpeed, false);
        yield return new WaitForSeconds(secondFadeSpeed);

        SceneManager.LoadScene("WinScreen");
    }

    public IEnumerator FadeToBlack()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1.0f, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);
    }
    public void SceneTransition()
    {
        StartCoroutine(LoadNextScene(0f, nextSceneIndex));
    }
    public IEnumerator LoadNextScene(float waitTime, int nextScene)
    {
        StartCoroutine(DisableAudioSources());
        yield return null;
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForSeconds(waitTime);
        fadeImage.CrossFadeAlpha(1.0f, secondFadeSpeed, false);
        yield return new WaitForSeconds(secondFadeSpeed);
        SceneManager.LoadScene(nextScene);
    }
}
