using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MAIN_MENU,
    GAME,
    PAUSE,
}

public class GameMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameState state = GameState.GAME; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q) && state == GameState.PAUSE)
        {
            QuitGame();
        }
    }

    void TogglePauseMenu()
    {
        switch (state)
        {
            case GameState.GAME: 
                PauseGame(); 
                break;
            case GameState.PAUSE:
                ResumeGame();
            break;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        state = GameState.PAUSE; 
        FirstPersonController.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        state = GameState.GAME;
        FirstPersonController.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
