// Date   : 16.04.2016 07:26
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    [SerializeField]
    private ShapeShiftState state;

    public ShapeShiftState State { get { return state; } }

    [SerializeField]
    private Animator animator;

    private bool inUse = false;

    private Skill nextSkill;

    [SerializeField]
    [Range(0, 4)]
    private int skillNumber;

    public int SkillNumber { get { return skillNumber; } }

    [SerializeField]
    private ShapeShift shapeShift;

    void Start () {
    
    }

    void Update () {
    
    }

    public void Use()
    {
        animator.SetTrigger("UseSkill");
        SetUse();
    }

    public void Clear()
    {
        animator.SetTrigger("ClearSkill");
    }

    public void SetUse()
    {
        inUse = true;
    }

    public void SetClear()
    {
        inUse = false;
        shapeShift.NextSkill();
    }

    public bool IsInUse()
    {
        return inUse;
    }

    public void CantUse()
    {
        animator.SetTrigger("UnableToUseSkill");
    }

}
