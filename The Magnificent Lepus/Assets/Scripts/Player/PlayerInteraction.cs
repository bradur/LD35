using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ShapeShiftState
{
    None,
    Bounce,
    Drill,
    Glide,
    Dash
}

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField]
    private List<string> drillable = new List<string>();

    [SerializeField]
    private ShapeShiftState state;

    [SerializeField]
    private Rigidbody2D rb2d;

    private float originalGravityScale;

    [SerializeField]
    [Range(0, 1)]
    private float glideGravityScale;

    [SerializeField]
    private CircleCollider2D collider;
    private PhysicsMaterial2D originalMaterial;

    [SerializeField]
    private PhysicsMaterial2D bounceMaterial;

    [SerializeField]
    private Animator animator;

    private bool isAnimating = false;

    private string animationQueue = "";

    private string[] bounces = new[] { "Bounce 1", "Bounce 2" };

    // Use this for initialization
    void Start()
    {
        originalGravityScale = rb2d.gravityScale;
        originalMaterial = collider.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == ShapeShiftState.Drill)
        {
            if (drillable.Contains(collision.gameObject.tag))
            {
                collision.gameObject.GetComponent<InteractiveObstacle>().Kill();
            }
        }
        else if (state == ShapeShiftState.Bounce)
        {
            SoundManager.main.Play(bounces[Random.Range(0, bounces.Length)]);
        }
        if (collision.gameObject.tag == "Respawn")
        {
            UIManager.main.SpawnPopup(
                "Failure!",
                "You fell off the face of the Earth!\n\nPress <size=60>" + OptionsManager.main.GetKeyCode("Restart") + "</size> to retry.",
                true
            );
        }
    }

    public void SetState(ShapeShiftState newState)
    {
        ClearState();

        if (state == newState)
        {
            animator.SetTrigger("End");
        }

        state = newState;

        if (state == ShapeShiftState.Bounce)
        {
            collider.sharedMaterial = bounceMaterial;
            StartAnimation("Bounce");
        }

        if (state == ShapeShiftState.Glide)
        {
            rb2d.gravityScale = glideGravityScale;
            StartAnimation("Glide");
            SoundManager.main.Play("Glide");
        }

        if (state == ShapeShiftState.Drill)
        {
            StartAnimation("Drill");
            SoundManager.main.Play("Drill");
        }
    }

    void StartAnimation(string animationTrigger)
    {
        ResetTriggers();
        animator.SetTrigger("End");
        animator.SetTrigger(animationTrigger);
        /*if (!isAnimating) {
            animator.SetTrigger(animationTrigger);
            isAnimating = true;
            animationQueue = "";
        }
        else
        {
            Debug.Log("Put <b>" + animationTrigger + "</b> to queue.");
            animationQueue = animationTrigger;
            animator.SetTrigger("End");
        }*/
    }

    void ResetTriggers()
    {
        animator.ResetTrigger("End");
        animator.ResetTrigger("Drill");
        animator.ResetTrigger("Glide");
        animator.ResetTrigger("Bounce");
    }

    public void AnimationFinished()
    {
        isAnimating = false;
        if (animationQueue != "")
        {
            StartAnimation(animationQueue);
        }
    }

    public void ClearState()
    {
        rb2d.gravityScale = originalGravityScale;
        collider.sharedMaterial = originalMaterial;
        state = ShapeShiftState.None;
    }
}
