// Date   : 16.04.2016 18:25
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoPopup : MonoBehaviour {

    [SerializeField]
    private Text titleTxt;
    [SerializeField]
    private Text descriptionTxt;

    [SerializeField]
    private Animator animator;

    public void Init(string title, string description)
    {
        titleTxt.text = title;
        descriptionTxt.text = description;
        animator.SetTrigger("Start");
    }

    public void Kill()
    {
        animator.SetTrigger("End");
    }

    public void AnimationEnded()
    {
        Destroy(gameObject);
    }
}
