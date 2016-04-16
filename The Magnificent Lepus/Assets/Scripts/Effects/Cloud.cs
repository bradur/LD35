// Date   : 16.04.2016 15:21
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    [SerializeField]
    [Range(0f, 5f)]
    private float speed;

    private float nextX;

    private float timer;

    [SerializeField]
    [Range(0f, 5f)]
    private float perlinNoiseInterval;

    void Start () {
        nextX = 0.2f;
    }

    public void Init(float newSpeed, float newNoiseInterval)
    {
        this.perlinNoiseInterval = newNoiseInterval;
        this.speed = newSpeed;
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer > perlinNoiseInterval)
        {
            nextX = Mathf.PerlinNoise(transform.position.x, transform.position.y);
            timer = 0f;
        }
        transform.position = new Vector3(transform.position.x + nextX * speed, transform.position.y, 0f);
    }
}
