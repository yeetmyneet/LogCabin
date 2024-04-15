using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainCamScene1 : MonoBehaviour {
    #region Play Button
    public void OpenScene2Button ( ) {
		SimpleSceneFader.ChangeSceneWithFade ("Test Scene 2");
	}
    #endregion Play Button
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
}
