using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene("GasStation");
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            SceneManager.LoadScene("Cabin");
        }
    }
}
