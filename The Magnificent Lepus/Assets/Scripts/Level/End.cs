// Date   : 16.04.2016 16:46
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            GameManager.main.PassLevel();
            UIManager.main.SpawnPopup(
                "Success!",
                "You passed the level!\n\n Press " + OptionsManager.main.GetKeyCode("Next Level") + " to go to the next level or " + OptionsManager.main.GetKeyCode("Restart") + " to retry this one.",
                true
            );
            SoundManager.main.Play("Victory");
        }
    }
}
