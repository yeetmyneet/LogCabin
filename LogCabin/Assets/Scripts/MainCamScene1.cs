using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    #region Play
    public void OpenScene2Button ( ) {
		SimpleSceneFader.ChangeSceneWithFade ("Cabin");
	}
    #endregion Play
    #region Quit
    public void Quit()
    {
		SimpleSceneFader.ChangeSceneWithFade("QuitGame");
    }
    #endregion Quit
    #region Endless Mode
    public void Endless()
    {
        SimpleSceneFader.ChangeSceneWithFade("Scripting Test Scene");
    }
    #endregion Endless Mode
    public void MainMenu()
    {
        SimpleSceneFader.ChangeSceneWithFade("MainMenu");
    }
}
