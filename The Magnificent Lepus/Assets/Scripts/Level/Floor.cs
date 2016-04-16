// Date   : 16.04.2016 16:50
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

    private float collisionTimer;

    [SerializeField]
    [Range(0.5f, 3f)]
    private float collisionStayUntilPrompt = 0.5f;

    private bool popupSpawned = false;

    void Start () {
    
    }

    void Update () {
        if (collisionTimer > collisionStayUntilPrompt && !popupSpawned)
        {
            UIManager.main.SpawnPopup(
                "Failure!",
                "Do you want to try again?\n\nPress " + OptionsManager.main.GetKeyCode("Restart"),
                true
            );
            popupSpawned = true;
            collisionTimer = 0f;
        }
    }

    void OnCollisionStay2D(Collision2D collision2D){
        if (collision2D.gameObject.tag == "Player")
        {
            collisionTimer += Time.deltaTime;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collisionTimer = 0f;
        }
    }
}
