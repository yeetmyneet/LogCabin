using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] Canvas pauseMenu;
	[SerializeField] Canvas crosshair;
	[SerializeField] GameObject scriptToDisable;
	[SerializeField] ObjectiveUI objectiveUI;
	[SerializeField] MonoBehaviour timer;
	[SerializeField] RaycastShoot raycastShoot;
	[SerializeField] Collectables collect;
	[SerializeField] FirstPersonController FPC;
	[SerializeField] AudioSource MenuAudioSource;

    private void Start()
    {
		MenuAudioSource.Pause();
		pauseMenu.enabled = false;
		crosshair.enabled = true;
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
		{
			pauseMenu.enabled = true;
			crosshair.enabled = false;
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.Confined;
			FPC.enabled = false;
			timer.enabled = false;
			raycastShoot.enabled = false;
			objectiveUI.enabled = false;
			collect.enabled = false;
			scriptToDisable.SetActive(false);
			DisableAudio();
		}
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		crosshair.enabled = true;
		scriptToDisable.SetActive(true);
		FPC.enabled = true;
		timer.enabled = true;
		objectiveUI.enabled = true;
		collect.enabled = true;
		raycastShoot.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		EnableAudio();
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
		EnableAudio();
	}

	public void LoadPauseMenu()
	{
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.Confined;
		pauseMenu.enabled = true;
	}
	void DisableAudio()
    {
		// Find all audio sources in the scene
		AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
		foreach (AudioSource audioSource in allAudioSources)
		{
			if (audioSource.CompareTag("MenuAudio"))
			{
				audioSource.UnPause();
			}
			else
			{
				if (audioSource.isPlaying)
				{
					audioSource.Pause();
					Debug.Log("paused audio source");
				}
			}
		}
	}
	void EnableAudio()
    {
		// Find all audio sources in the scene
		AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
		foreach (AudioSource audioSource in allAudioSources)
		{
			if (audioSource.CompareTag("MenuAudio"))
			{
				if (audioSource.isPlaying)
				{
					audioSource.Pause();
				}
			}
			else
			{
				audioSource.UnPause();
				Debug.Log("unpaused audio source");
			}
		}
	}
}