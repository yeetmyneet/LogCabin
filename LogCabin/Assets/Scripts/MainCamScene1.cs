using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    public string previousBuildIndex = "prevBuildIndex";
    public string endlessModeTrigger = "EndlessTrigger";
    public void OpenScene2Button () {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(endlessModeTrigger, 0);
        Debug.Log("Set endlessmodetrigger to 0");
        PlayerPrefs.SetFloat("StopwatchTime", 0f);
        Debug.Log("set stopwatch time to 0");
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SimpleSceneFader.ChangeSceneWithFade ("Cabin");
	}
    public void Quit()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SimpleSceneFader.ChangeSceneWithFade("QuitGame");
    }
    public void Endless()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(endlessModeTrigger, 1);
        Debug.Log("Set endlessmodetrigger to 1");
        PlayerPrefs.SetFloat("StopwatchTime", 0f);
        Debug.Log("set stopwatch time to 0");
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SimpleSceneFader.ChangeSceneWithFade("Cabin");
    }
    public void MainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SimpleSceneFader.ChangeSceneWithFade("MainMenu");
    }
    public void Tutorial()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SimpleSceneFader.ChangeSceneWithFade("Tutorial");
    }
    public void MainMenuNoFade()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        SceneManager.LoadScene("MainMenu");
    }
    public void EndlessCheck(int endless)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (PlayerPrefs.GetInt(endlessModeTrigger, 0) == 1) { endless = 1; }
        else { endless = 0; }
        Debug.Log("endless mode: " + endless);
        if (endless == 1)
        {
            PlayerPrefs.SetInt(endlessModeTrigger, 1);
            Debug.Log("Set endlessmodetrigger to 1");
        }
        else
        {
            PlayerPrefs.SetInt(endlessModeTrigger, 0);
            Debug.Log("Set endlessmodetrigger to 0");
        }
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        Debug.Log("previous build index:" + PlayerPrefs.GetInt(previousBuildIndex, 0));
        PlayerPrefs.SetFloat("StopwatchTime", 0f);
        Debug.Log("set stopwatch time to 0");
        SimpleSceneFader.ChangeSceneWithFade("Cabin");
    }
}
