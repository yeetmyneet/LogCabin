using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    public void OpenScene2Button ( ) {
		SimpleSceneFader.ChangeSceneWithFade ("Test Scene 2");
	}
    public void Quit()
    {
		SimpleSceneFader.ChangeSceneWithFade("QuitGame");
    }
	public void Credits()
    {
		SimpleSceneFader.ChangeSceneWithFade("Credits");
    }
	public void MainMenu()
    {
		SimpleSceneFader.ChangeSceneWithFade("MainMenu");
    }
}
