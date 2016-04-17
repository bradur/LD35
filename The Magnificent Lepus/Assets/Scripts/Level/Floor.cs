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

    private InfoPopup currentPopup;

    void Start () {
    
    }

    void Update () {
        if (collisionTimer > collisionStayUntilPrompt && currentPopup == null)
        {
            currentPopup = UIManager.main.SpawnPopup(
                "Failure!",
                "Do you want to try again?\n\nPress <size=60>" + OptionsManager.main.GetKeyCode("Restart") + "</size>",
                true
            );
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
