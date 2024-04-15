using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutMusic : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the AudioSource component containing the music

    public float fadeDuration = 2f; // Duration of the fade-out effect in seconds

    public void FadeOutButtonFunction()
    {
        // Check if AudioSource is assigned
        if (musicSource == null)
        {
            Debug.LogError("Music source is not assigned to MusicFadeOut script!");
            return;
        }

        // Start the fading out process
        StartCoroutine(FadeOut());
    }

    #region Fade Out Coroutine
    IEnumerator FadeOut()
    {
        // Get the initial volume of the music
        float startVolume = musicSource.volume;

        // Calculate the rate of volume decrease per second
        float rate = startVolume / fadeDuration;

        // Fade out the music
        while (musicSource.volume > 0)
        {
            musicSource.volume -= rate * Time.deltaTime;
            yield return null;
        }

        // Ensure volume is set to zero and stop the music
        musicSource.volume = 0;
        musicSource.Stop();
    }
    #endregion Fade Out Coroutine
}
