using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    public string previousBuildIndex = "prevBuildIndex";
    public string endlessModeTrigger = "EndlessTrigger";
    public void OpenScene2Button ( ) {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(endlessModeTrigger, 0);
        Debug.Log("Set endlessmodetrigger to 0");
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade ("Cabin");
	}
    public void Quit()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade("QuitGame");
    }
    public void Endless()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(endlessModeTrigger, 1);
        Debug.Log("Set endlessmodetrigger to 1");
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade("Cabin");
    }
    public void MainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade("MainMenu");
    }
    public void Tutorial()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade("Tutorial");
    }
    public void MainMenuNoFade()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
}
