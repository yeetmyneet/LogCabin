using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    public void OpenScene2Button ( ) {
		SimpleSceneFader.ChangeSceneWithFade ("Cabin");
	}
    public void Quit()
    {
		SimpleSceneFader.ChangeSceneWithFade("QuitGame");
    }
    public void Endless()
    {
        SimpleSceneFader.ChangeSceneWithFade("Scripting Test Scene");
    }
    public void MainMenu()
    {
        SimpleSceneFader.ChangeSceneWithFade("MainMenu");
    }
    public void Tutorial()
    {
        SimpleSceneFader.ChangeSceneWithFade("Tutorial");
    }
}
