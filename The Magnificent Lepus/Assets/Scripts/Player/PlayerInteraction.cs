using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ShapeShiftState
{
    None,
    Bounce,
    Drill,
    Glide
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
    private PolygonCollider2D collider;
    private PhysicsMaterial2D originalMaterial;

    [SerializeField]
    private PhysicsMaterial2D bounceMaterial;

    [SerializeField]
    private SpriteRenderer leftWing;
    [SerializeField]
    private SpriteRenderer rightWing;

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
    }

    public void SetState(ShapeShiftState newState)
    {
        if (newState != state)
        {
            if (state == ShapeShiftState.Glide)
            {
                rb2d.gravityScale = originalGravityScale;
            }

            else if (state == ShapeShiftState.Bounce)
            {
                collider.sharedMaterial = originalMaterial;
            }

            else if (state == ShapeShiftState.Glide)
            {
                leftWing.enabled = true;
                rightWing.enabled = true;
            }
        }

        state = newState;

        if (state == ShapeShiftState.Glide)
        {
            rb2d.gravityScale = glideGravityScale;
        }

        if (state == ShapeShiftState.Bounce)
        {
            collider.sharedMaterial = bounceMaterial;
        }

        if (state == ShapeShiftState.Glide)
        {
            leftWing.enabled = true;
            rightWing.enabled = true;
        }
    }

    public void ClearState()
    {
        rb2d.gravityScale = originalGravityScale;
        collider.sharedMaterial = originalMaterial;
        leftWing.enabled = false;
        rightWing.enabled = false;
    }
}
