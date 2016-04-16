// Date   : 16.04.2016 07:17
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(PlayerInteraction))]
public class ShapeShift : MonoBehaviour {

    [SerializeField]
    private PlayerInteraction pi;

    [SerializeField]
    private List<Skill> skills = new List<Skill>();

    private string[] keys = 
    {
        "FirstSkill",
        "SecondSkill",
        "ThirdSkill",
        "FourthSkill"
    };

    private bool isOnCoolDown = false;

    void Update () {
        for (int i = 0; i < keys.Length; i += 1)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode(keys[i])))
            {
                Debug.Log(OptionsManager.main.GetKeyCode(keys[i]) + " was pressed!");
                UseSkill(i);
                break;
            }
        }
    }

    void UseSkill(int skillNum)
    {
        Skill skill = skills[skillNum];
        if (skill != null)
        {
            if (!isOnCoolDown)
            {
                // shapeshift here
                pi.SetState(skill.State);
            }
        }
    }
}
