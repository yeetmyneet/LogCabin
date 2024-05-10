using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    public string previousBuildIndex = "prevBuildIndex";
    public void OpenScene2Button ( ) {
        Scene currentScene = SceneManager.GetActiveScene();
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
        PlayerPrefs.SetInt(previousBuildIndex, currentScene.buildIndex);
        SimpleSceneFader.ChangeSceneWithFade("Scripting Test Scene");
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
