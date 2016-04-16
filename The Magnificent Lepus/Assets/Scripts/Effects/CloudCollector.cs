// Date   : 16.04.2016 16:01
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour
{
    [SerializeField]
    private CloudManager cloudManager;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Cloud")
        {
            cloudManager.CloudCollected(collider2D.GetComponent<Cloud>());
        }
    }

}
