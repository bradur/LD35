// Date   : 16.04.2016 07:14
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionsManager : MonoBehaviour {

    [SerializeField]
    private List<string> keyNames = new List<string>();

    [SerializeField]
    private List<KeyCode> keyCodes = new List<KeyCode>();

    public static OptionsManager main;

    void Awake()
    {
        main = this;
    }

    void Start () {
    
    }

    void Update () {
    
    }

    public KeyCode GetKeyCode(string key)
    {
        if (keyNames.Contains(key))
        {
            return keyCodes[keyNames.IndexOf(key)];
        }
        return KeyCode.None;
    }
}
