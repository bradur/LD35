// Date   : 16.04.2016 18:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private string title;
    public string Title { get { return title; } }

    public Transform PlayerTransform { get { return playerTransform; } }

    void Start () {
    
    }

    void Update () {
    
    }

    public void Kill()
    {
        // TODO
        Destroy(gameObject);
    }
}
