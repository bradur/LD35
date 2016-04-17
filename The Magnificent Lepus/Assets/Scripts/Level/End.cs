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
        }
    }
}
