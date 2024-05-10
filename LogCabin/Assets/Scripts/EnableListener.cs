using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableListener : MonoBehaviour
{
    void Start()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
