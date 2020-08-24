using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject loader;

    public void playGame() {
        loader.SetActive(true);
        if (loader.activeInHierarchy == true) {
            SceneManager.LoadScene("SelectionMenu");
        }
    }
}
