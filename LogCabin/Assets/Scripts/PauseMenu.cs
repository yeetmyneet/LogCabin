using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] Canvas pauseMenu;
	[SerializeField] GameObject scriptToDisable;
	[SerializeField] FirstPersonController FPC;

    private void Start()
    {
		pauseMenu.enabled = false;
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.L) && Time.timeScale == 1)
		{
			pauseMenu.enabled = true;
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.Confined;
			FPC.enabled = false;
			scriptToDisable.SetActive(false);
		}
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		scriptToDisable.SetActive(true);
		FPC.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadPauseMenu()
	{
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.Confined;
		pauseMenu.enabled = true;
	}
}