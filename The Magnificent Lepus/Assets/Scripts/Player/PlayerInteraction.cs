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

    // Use this for initialization
    void Start()
    {

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
        state = newState;
    }
}
