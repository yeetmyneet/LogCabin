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
            Destroy(collision.gameObject);

            if (CupCollect == 5)
            {
                collection.text = "Make Coffee!!";
            }
        }

        if (collision.gameObject.tag == "Matches")
        {
            MatchesCollected++;
            collection.text = "Current Collectables: " + MatchesCollected;
            Destroy(collision.gameObject);

            if(MatchesCollected == 2)
            {
                collection.text = "Start a Fire!";
            }
        }

        if (collision.gameObject.tag == "Dolls")
        {
            DollsCollected++;
            collection.text = "Current Collectables: " + DollsCollected;
            Destroy(collision.gameObject); 

            if (DollsCollected == 4)
            {
                collection.text = "Completed the Collection";
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            coolText.enabled = !coolText.enabled;
        }
    }
}
