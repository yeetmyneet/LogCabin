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
    public IEnumerator LoadWinScreen()
    {
        StartCoroutine(DisableAudioSources());
        yield return null;
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1.0f, secondFadeSpeed, false);
        yield return new WaitForSeconds(secondFadeSpeed);

        SceneManager.LoadScene("WinScreen");
    }
}
