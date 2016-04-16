// Date   : 16.04.2016 06:40
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class InteractiveObstacle : MonoBehaviour {

    void Start () {
    
    }

    void Update () {
    
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
