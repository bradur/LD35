// Date   : 16.04.2016 18:42
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour {

    public static WorldManager main;

    [SerializeField]
    private List<Level> levels = new List<Level>();

    public int LevelCount { get { return levels.Count; } }

    private Level currentLevel = null;

    [SerializeField]
    private Transform worldContainer;

    [SerializeField]
    private bool debugMode = false;

    void Awake ()
    {
        main = this;
    }

    void Start()
    {
        if (!debugMode) { 
            LoadLevel(GameManager.main.CurrentLevel);
        }
    }

    public void LoadLevel(int level)
    {
        if (level <= levels.Count - 1) {
            if (currentLevel != null)
            {
                currentLevel.Kill();
            }
            currentLevel = Instantiate(levels[level]);
            currentLevel.transform.parent = worldContainer;
            currentLevel.transform.position = Vector3.zero;
            Camera.main.GetComponent<Camera2DFollow>().SetTarget(currentLevel.PlayerTransform);
        }
    }

}
