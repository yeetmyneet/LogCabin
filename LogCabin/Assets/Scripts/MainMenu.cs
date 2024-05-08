using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public new AudioSource audio;
    [SerializeField] public AudioClip hover;
    private string booleanKey = "IsEnabled";
    public GameObject enabledObject;

    void Awake()
    {
        if (!PlayerPrefs.HasKey(booleanKey))
        {
            // If the key doesn't exist, set its default value to false
            PlayerPrefs.SetInt(booleanKey, 0); // 0 represents false
        }
        Scene previousScene = SceneManager.GetActiveScene();
        if (previousScene.name == "WinScreen")
        {
            // Set IsEnabled to true
            PlayerPrefs.SetInt(booleanKey, 1); // 1 represents true
            PlayerPrefs.Save(); // Make sure to call Save to persist the changes
        }
    }

    void Start()
    {
        bool isEnabled = PlayerPrefs.GetInt(booleanKey, 1) == 1;
        enabledObject.SetActive(isEnabled);
    }

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
