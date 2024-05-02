using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutDeath : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 2f;

    private void Awake()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);
    }

    public IEnumerator FadeToBlackAndLoadScene()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);

        fadeImage.CrossFadeAlpha(1.0f, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);

        SceneManager.LoadScene("DeathScreen");
    }
}
