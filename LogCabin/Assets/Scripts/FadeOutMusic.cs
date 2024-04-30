using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutMusic : MonoBehaviour
{
    public AudioSource musicSource; 
    public float fadeDuration = 2f;

    public void FadeOutButtonFunction()
    {
        if (musicSource == null) { Debug.LogError("Music source is not assigned to MusicFadeOut script!"); }
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float startVolume = musicSource.volume;

        float rate = startVolume / fadeDuration;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= rate * Time.deltaTime;
            yield return null;
        }
        musicSource.volume = 0;
        musicSource.Stop();
    }
}
