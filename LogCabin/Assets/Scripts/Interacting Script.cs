using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingScript : MonoBehaviour
{
    public bool isInteracting = false;
    //[SerializeField] public MovementScript movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = true;
        }
    }
}
