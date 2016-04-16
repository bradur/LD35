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

    // Use this for initialization
    void Start()
    {
        originalGravityScale = rb2d.gravityScale;
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
        if (state == ShapeShiftState.Glide && newState != ShapeShiftState.Glide)
        {
            rb2d.gravityScale = originalGravityScale;
        }
        state = newState;
        if (state == ShapeShiftState.Glide)
        {
            rb2d.gravityScale = glideGravityScale;
        }
    }
}
