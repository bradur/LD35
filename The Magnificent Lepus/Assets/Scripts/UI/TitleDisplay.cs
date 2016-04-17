// Date   : 17.04.2016 18:31
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class TitleDisplay : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;

    [SerializeField]
    private Animator animator;

    public void Init(string title)
    {
        txtComponent.text = title;
        animator.enabled = true;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
