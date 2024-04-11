using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public new AudioSource audio;
    [SerializeField] public AudioClip hover;
    public void Play()
    {
        StartCoroutine(PlayAudio());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
