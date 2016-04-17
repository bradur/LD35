// Date   : 16.04.2016 18:40
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager main;

    [SerializeField]
    private int currentLevel = 0;

    public int CurrentLevel { get { return currentLevel; } }

    private bool waitForNextLevelConfirmation = false;
    public bool WaitForNextLevelConfirmation { get { return waitForNextLevelConfirmation; } }
    private bool waitForGameEndConfirm = false;
    
    private bool waitForPauseMenuConfirm = false;

    void Awake()
    {
        main = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (waitForNextLevelConfirmation)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                RestartLevel();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Next Level")))
            {
                currentLevel++;
                LoadLevel(currentLevel);
            }
        }
        else if (waitForGameEndConfirm)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                RestartLevel();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Main Menu")))
            {
                LoadMainMenu();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Exit")))
            {
                QuitGame();
            }
        }
        else if (waitForPauseMenuConfirm)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                RestartLevel();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Main Menu")))
            {
                LoadMainMenu();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Pause Menu")))
            {
                UIManager.main.KillAllPopups();
            }
        }
        else
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                RestartLevel();
            }
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Pause Menu")))
            {
                waitForPauseMenuConfirm = true;
                UIManager.main.SpawnPopup(
                    "Game is paused",
                    OptionsManager.main.GetKeyCode("Pause Menu") + " to resume game\n" +
                    OptionsManager.main.GetKeyCode("Restart") + " to restart this level\n" +
                    OptionsManager.main.GetKeyCode("Main Menu") + " to go to main menu\n" +
                    OptionsManager.main.GetKeyCode("Quit Game While Paused") + " to quit to desktop\n",
                    true
                );
            }
        }
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        UIManager.main.KillAllPopups();
        waitForNextLevelConfirmation = false;
        waitForPauseMenuConfirm = false;
        waitForGameEndConfirm = false;
        LoadLevel(currentLevel);
    }

    void LoadLevel(int level)
    {
        Time.timeScale = 1f;
        UIManager.main.KillAllPopups();
        waitForNextLevelConfirmation = false;
        waitForPauseMenuConfirm = false;
        waitForGameEndConfirm = false;
        //Application.LoadLevel(0); // is this needed?
        WorldManager.main.LoadLevel(level);
    }

    void LoadMainMenu()
    {
        // TODO
        Debug.Log("<b>PLACEHOLDER</b>: Load Main Menu");
    }

    void QuitGame()
    {
        // TODO
        Application.Quit();
    }

    public void PassLevel()
    {
        waitForNextLevelConfirmation = true;
    }

    public void FinishGame()
    {
        waitForGameEndConfirm = true;
    }
}
