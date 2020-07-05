using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILButtonManager : MonoBehaviour
{
    public GameObject[] gameObjects;

    public void ToggleButton(int index) {
        if (!gameObjects[index].activeInHierarchy) {
            foreach (GameObject item in gameObjects) {
                item.SetActive(false);
            }
            gameObjects[index].SetActive(true);
        } else if (gameObjects[index].activeInHierarchy) {
            gameObjects[index].SetActive(false);
        }
    }
}
