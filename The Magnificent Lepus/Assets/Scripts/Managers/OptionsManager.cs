// Date   : 16.04.2016 07:14
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    [SerializeField]
    private KeyCode FirstSkillKey;
    [SerializeField]
    private KeyCode SecondSkillKey;
    [SerializeField]
    private KeyCode ThirdSkillKey;
    [SerializeField]
    private KeyCode FourthSkillKey;

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
        if (key == "FirstSkill")
        {
            return FirstSkillKey;
        }
        else if (key == "SecondSkill")
        {
            return SecondSkillKey;
        }
        else if (key == "ThirdSkill")
        {
            return ThirdSkillKey;
        }
        else if (key == "FourthSkill")
        {
            return FourthSkillKey;
        }
        return KeyCode.None;
    }
}
