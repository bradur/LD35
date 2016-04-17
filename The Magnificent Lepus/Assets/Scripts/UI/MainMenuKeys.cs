// Date   : 17.04.2016 19:17
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuKeys : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;

    void Start () {
        string continuetxt = "";
        if (PlayerPrefs.GetInt("continue") > 0)
        {
            KeyCode keyCode = OptionsManager.main.GetKeyCode("Continue");
            string keyname = keyCode.ToString();
            if (keyCode == KeyCode.Return)
            {
                keyname = "Enter";
            }
            continuetxt = "<size=30>" + keyname + "</size> continue\n";
        }
        txtComponent.text = continuetxt +
                            "<size=30>" + OptionsManager.main.GetKeyCode("Start") + "</size> start the game\n" + 
                            "<size=30>" + OptionsManager.main.GetKeyCode("Exit") + "</size> quit the game";
    }

    void Update () {
    
    }
}
