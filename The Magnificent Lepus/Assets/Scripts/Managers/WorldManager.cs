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

    private Level currentLevel = null;

    [SerializeField]
    private Transform worldContainer;

    void Awake ()
    {
        main = this;
    }

    void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int level)
    {
        if (level > levels.Count - 1)
        {
            UIManager.main.SpawnPopup(
                "The end",
                "You did it! You passed through each level! Press " + OptionsManager.main.GetKeyCode("Exit") + " to quit or " + OptionsManager.main.GetKeyCode("Main Menu") + " to go back to main menu.",
                true
            );
        }
        else
        {
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

    void Update () {
    
    }
}
