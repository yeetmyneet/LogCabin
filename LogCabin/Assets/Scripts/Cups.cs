using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{
    [SerializeField] int CupCollect = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cups")
        {
            CupCollect++;
            Debug.Log("collected cup");
            Destroy(collision.gameObject);

            if (CupCollect == 10)
            {
                Debug.Log("Collected all cups!");
            }
        }
    }
}
