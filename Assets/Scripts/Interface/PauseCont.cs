using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCont : MonoBehaviour
{
    public GameObject mainMenuButton;
    public GameObject optionsButton;
    public GameObject exitGameButton;

    public GameObject pauseMenuEmpty;

    private bool isPaused = false;

    public void returnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame() {
        Application.Quit();
    }

    public void togglePause() {
        isPaused = !isPaused;
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            isPaused = !isPaused;
        }
        if (isPaused == false) {
            pauseMenuEmpty.SetActive(false);
        } else if (isPaused == true) {
            pauseMenuEmpty.SetActive(true);
        }
    }
}
