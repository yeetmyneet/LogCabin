using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] Canvas pauseMenu;
    void Update()
	{

		if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pauseMenu.enabled = true;
			Cursor.lockState = CursorLockMode.Confined;
		}
		else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
		{
			Resume();
		}
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Main Menu");
	}

	public void LoadPauseMenu()
	{
		Time.timeScale = 0;
		pauseMenu.enabled = true;
	}
}