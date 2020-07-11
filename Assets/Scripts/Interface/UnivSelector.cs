using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnivSelector : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject singlePlayerMenu;
    public GameObject multiPlayerMenu;
    public GameObject loader;

    public void playSinglePlayer() {
        mainMenu.SetActive(false);
        singlePlayerMenu.SetActive(true);
    }
    
    public void playMultiPlayer() {
        mainMenu.SetActive(false);
        multiPlayerMenu.SetActive(true);
    }
    
    public void playReturn() {
        singlePlayerMenu.SetActive(false);
        multiPlayerMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void playGame() {
        loader.SetActive(true);
        if (loader.activeInHierarchy == true) {
            SceneManager.LoadScene("WorldLoader");
        }
    }
}
