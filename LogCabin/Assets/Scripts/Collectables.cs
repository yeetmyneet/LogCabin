using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectables : MonoBehaviour
{
    [SerializeField] int CupCollect = 0;
    [SerializeField] int MatchesCollected = 0;
    [SerializeField] int DollsCollected = 0;
    [SerializeField] Canvas coolText;
    [SerializeField] TextMeshProUGUI collection;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cups")
        {
            CupCollect++;
            collection.text = "Current Collectables: " + CupCollect;
            Debug.Log("collected cup");
            Destroy(collision.gameObject);

            if (CupCollect == 10)
            {
                collection.text = "All Cups Collected!";
            }
        }

        if (collision.gameObject.tag == "Matches")
        {
            MatchesCollected++;
            Debug.Log("Collected matches");
            collection.text = "Current Collectables: " + MatchesCollected;
            Destroy(collision.gameObject);

            if(MatchesCollected == 5)
            {
                collection.text = "Start a Fire!";
            }
        }

        if (collision.gameObject.tag == "Dolls")
        {
            DollsCollected++;
            collection.text = "Current Collectables: " + DollsCollected;
            Debug.Log("Doll collected");
            Destroy(collision.gameObject); 

            if (DollsCollected == 4)
            {
                collection.text = "Completed the Collection";
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            coolText.enabled = !coolText.enabled;
        }
    }
}
