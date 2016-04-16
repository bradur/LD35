using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Blastoff : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0, 100)]
    private float speed;

    private bool inTheAir = false;
    public bool InTheAir { get { return inTheAir; } }

    // Use this for initialization
    void Start () {
    }

    public void Shoot()
    {
        if (rb2d.IsSleeping())
        {
            rb2d.WakeUp();
            foreach (Transform child in transform)
            {
                Rigidbody2D child_rb2d = child.GetComponent<Rigidbody2D>();
                if (child_rb2d != null)
                {
                    child_rb2d.WakeUp();
                }
            }
        }
        //rb2d.AddForce(transform.forward * speed, ForceMode2D.Impulse);

        rb2d.velocity = new Vector3(1, 1, 0) * speed;
        inTheAir = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Shoot")) && !InTheAir)
        {
            Shoot();
        }
    }
}
