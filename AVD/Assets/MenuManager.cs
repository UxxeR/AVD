using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private bool gameIsPaused = false;
    [SerializeField]
    private int currentScene = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        gameIsPaused = !gameIsPaused;
        menu.SetActive(gameIsPaused);

    }

    public void ResumeGame() {
        gameIsPaused = false;
        Time.timeScale = 1;
        menu.SetActive(gameIsPaused);
    }

    public void RestartGame() {
        gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }

    public void BackMenu() {
        gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame() {
        gameIsPaused = false;
        Time.timeScale = 1;
        Application.Quit();
    }
}
