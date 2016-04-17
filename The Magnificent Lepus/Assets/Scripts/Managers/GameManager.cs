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

    private bool waitForMainMenuConfirm = true;
    public bool WaitForMainMenuConfirmation { get { return waitForMainMenuConfirm; } }

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
                SoundManager.main.Play("Shortcut");
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Next Level")))
            {
                currentLevel++;
                SoundManager.main.Play("Shortcut");
                LoadLevel(currentLevel);
            }
        }
        else if (waitForGameEndConfirm)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                SoundManager.main.Play("Shortcut");
                RestartLevel();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Main Menu")))
            {
                SoundManager.main.Play("Shortcut");
                LoadMainMenu();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Exit")))
            {
                SoundManager.main.Play("Shortcut");
                QuitGame();
            }
        }
        else if (waitForPauseMenuConfirm)
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                SoundManager.main.Play("Shortcut");
                RestartLevel();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Main Menu")))
            {
                SoundManager.main.Play("Shortcut");
                LoadMainMenu();
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Pause Menu")))
            {
                SoundManager.main.Play("Shortcut");
                UIManager.main.KillAllPopups();
                waitForPauseMenuConfirm = false;
            }
        }
        else if (waitForMainMenuConfirm) {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Start")))
            {
                SoundManager.main.Play("Shortcut");
                WorldManager.main.StartGame();
                UIManager.main.KillAllPopups();
                waitForMainMenuConfirm = false;
            }
            else if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Exit")))
            {
                SoundManager.main.Play("Shortcut");
                QuitGame();
            }
        }
        else
        {
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Restart")))
            {
                SoundManager.main.Play("Shortcut");
                RestartLevel();
            }
            if (Input.GetKeyUp(OptionsManager.main.GetKeyCode("Pause Menu")))
            {
                SoundManager.main.Play("Shortcut");
                waitForPauseMenuConfirm = true;
                UIManager.main.SpawnPopup(
                    "Game is paused",
                    "<size=60>" + OptionsManager.main.GetKeyCode("Pause Menu") + "</size> to resume game\n" +
                    "<size=60>" + OptionsManager.main.GetKeyCode("Restart") + "</size> to restart this level\n" +
                    "<size=60>" + OptionsManager.main.GetKeyCode("Main Menu") + "</size> to go to main menu\n" +
                    "<size=60>" + OptionsManager.main.GetKeyCode("Quit Game While Paused") + "</size> to quit to desktop\n",
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
        waitForNextLevelConfirmation = false;
        waitForPauseMenuConfirm = false;
        waitForGameEndConfirm = false;
        waitForMainMenuConfirm = true;
        UIManager.main.OpenMainMenu();
    }

    void QuitGame()
    {
        // TODO
        Application.Quit();
    }

    public void PassLevel()
    {
        if (currentLevel >= WorldManager.main.LevelCount - 1)
        {
            waitForGameEndConfirm = true;
            UIManager.main.SpawnPopup(
                "The end",
                "You did it! You passed through each level! Press <size=60>" +
                OptionsManager.main.GetKeyCode("Exit") + "</size> to quit or <size=60>" +
                OptionsManager.main.GetKeyCode("Main Menu") + "</size> to go back to main menu.",
                true
            );
        }
        else {
            waitForNextLevelConfirmation = true;
            UIManager.main.SpawnPopup(
                "Success!",
                "You passed the level!\n\n Press <size=60>" +
                OptionsManager.main.GetKeyCode("Next Level") + "</size> to go to the next level or <size=60>" +
                OptionsManager.main.GetKeyCode("Restart") + "</size> to retry this one.",
                true
            );
            SoundManager.main.Play("Victory");
        }
    }

}
