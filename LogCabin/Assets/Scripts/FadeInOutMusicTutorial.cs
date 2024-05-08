using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class FadeInOutMusicTutorial : MonoBehaviour
{
    public AudioClip clipToFade;
    public float fadeDuration = 2f;
    public AudioMixerGroup mixerGroup; // If you want to control volume with Audio Mixer

    private AudioSource audioSource;
    private bool isFadingOut = false;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clipToFade;
        audioSource.loop = true;
        audioSource.outputAudioMixerGroup = mixerGroup; // Assigning mixer group if provided
        audioSource.Play();
        FadeIn();
    }

    public void FadeIn()
    {
        // Reset volume to 0 before fading in
        audioSource.volume = 0f;
        StartCoroutine(FadeToVolume(1f));
    }

    public void FadeOut()
    {
        if (!isFadingOut)
        {
            isFadingOut = true;
            StartCoroutine(FadeToVolume(0f, () =>
            {
                audioSource.Stop();
                isFadingOut = false;
            }));
        }
    }

    private System.Collections.IEnumerator FadeToVolume(float targetVolume, System.Action onComplete = null)
    {
        float currentVolume = audioSource.volume;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(currentVolume, targetVolume, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;

        onComplete?.Invoke();
    }
}
