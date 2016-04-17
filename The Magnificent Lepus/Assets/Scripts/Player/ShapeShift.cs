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

    private List<Skill> skills;

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

    [SerializeField]
    private bool[] skillsEnabled = {
        true,
        true,
        true,
        true
    };

    void Start()
    {
        skills = UIManager.main.GetSkills();
        for (int i = 0; i < skills.Count; i += 1)
        {
            skills[i].Init(this);
        }
        UIManager.main.SetSkills(skillsEnabled);
    }

    void Update () {
        for (int i = 0; i < keys.Length; i += 1)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode(keys[i])) && bo.InTheAir && skillsEnabled[i])
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
            }
            else if (!skill.IsInUse())
            {
                skill.Use();
                currentSkill = skill;
                pi.SetState(skill.State);
            }
            else
            {
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
