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
    private Blastoff bo;

    [SerializeField]
    private List<Skill> skills = new List<Skill>();

    private Skill currentSkill;
    private Skill nextSkill;

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
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode(keys[i])) && bo.InTheAir)
            {
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
            if (currentSkill != null && currentSkill.IsInUse() && currentSkill != skill)
            {
                currentSkill.Clear();
                nextSkill = skill;
                //Debug.Log("<b>Current skill:</b> " + currentSkill.name + ". Next skill: " + nextSkill.name);
            }
            else if (!skill.IsInUse())
            {
                //Debug.Log("<b>No skill in use. Use:</b> " + skill.name);
                skill.Use();
                currentSkill = skill;
                pi.SetState(skill.State);
            }
            else
            {
                //Debug.Log("<b>Disabling skill:</b> " + skill.name);
                skill.Clear();
                if (currentSkill != null)
                {
                    currentSkill.Clear();
                    currentSkill = null;
                }
                pi.SetState(ShapeShiftState.None);
                pi.ClearState();
            }
        }
    }

    public void NextSkill()
    {
        if (nextSkill != null)
        {
            UseSkill(nextSkill.SkillNumber);
            nextSkill = null;
        }
    }
}
