using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Blastoff : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0, 100)]
    private float speed;

    // Use this for initialization
    void Start () {
    }

    public void Shoot()
    {
        if (rb2d.IsSleeping())
        {
            rb2d.WakeUp();
        }
        //rb2d.AddForce(transform.forward * speed, ForceMode2D.Impulse);

        rb2d.velocity = new Vector3(1, 1, 0) * speed;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }
}
