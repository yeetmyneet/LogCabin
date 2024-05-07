using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] int CupCollect = 0;
    [SerializeField] int MatchesCollected = 0;
    [SerializeField] int DollsCollected = 0;
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

        if (collision.gameObject.tag == "Matches")
        {
            MatchesCollected++;
            Debug.Log("Collected matches");
            Destroy(collision.gameObject);

            if(MatchesCollected == 5)
            {
                Debug.Log("Every match collected");
            }
        }

        if (collision.gameObject.tag == "Dolls")
        {
            DollsCollected++;
            Debug.Log("Doll collected");
            Destroy(collision.gameObject); 

            if (DollsCollected == 4)
            {
                Debug.Log("Collected Every Doll");
            }
        }
    }
}
