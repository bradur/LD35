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

    void Start () {
    
    }

    void Update () {
    
    }

    public void Use()
    {
        animator.SetTrigger("UseSkill");
    }

    public void CantUse()
    {
        animator.SetTrigger("UnableToUseSkill");
    }
}
