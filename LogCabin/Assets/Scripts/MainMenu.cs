using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public new AudioSource audio;
    [SerializeField] public AudioClip hover;
    public string booleanKey = "IsEnabled";
    public string endlessModeTrigger = "EndlessTrigger";
    public string previousBuildIndex = "prevBuildIndex";
    private int previousSceneBuildIndex;
    public GameObject enabledObject;

    void Awake()
    {
        enabledObject.SetActive(false);
        // Get the current scene
        int passedValue = PlayerPrefs.GetInt(previousBuildIndex, 0);
        Debug.Log("passedvalue: " + passedValue);
        if (passedValue == 2 || passedValue == 3 || passedValue == 4 || passedValue == 7 || passedValue == 8)
        {
            Debug.Log("came from win screen");
            return;
        }
        else
        {
#if UNITY_EDITOR
            PlayerPrefs.DeleteKey(booleanKey); // Delete the boolean key only if running in the Unity Editor
            Debug.Log("being ran in unity editor");
            PlayerPrefs.Save(); // Save the changes
#endif
        }
        if (!PlayerPrefs.HasKey(endlessModeTrigger))
        {
            PlayerPrefs.SetInt(endlessModeTrigger, 0);
            Debug.Log("Created endlessModeTrigger");
        }
    }
    void Start()
    {
        bool isEnabled = false;
        if (!PlayerPrefs.HasKey(booleanKey))
        {
            PlayerPrefs.SetInt(booleanKey, 0);
            Debug.Log("Created booleanKey");
        }
        else
        {
            Debug.Log("already has booleanKey");
        }
        if (PlayerPrefs.GetInt(booleanKey, 0) == 1)
        {
            isEnabled = true;
            Debug.Log("The boolean key is set to true.");
        }
        else
        {
            isEnabled = false;
            Debug.Log("The boolean key is not set to true.");
        }
        Debug.Log("checked for completion");
        enabledObject.SetActive(isEnabled);
        Debug.Log("set button to active/inactive");
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
    void OnApplicationQuit()
    {
        // Delete the PlayerPrefs value when the game exits
        PlayerPrefs.DeleteKey(previousBuildIndex);
        Debug.Log("Value previousBuildIndex deleted from PlayerPrefs on application quit.");
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Deleted Data");
    }
}
