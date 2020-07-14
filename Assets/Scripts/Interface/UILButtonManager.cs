using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILButtonManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public bool checkSames = false;
    int prevIndex;

    public void ToggleButton(int index) {
        if (!gameObjects[index].activeInHierarchy) {
            foreach (GameObject item in gameObjects) {
                item.SetActive(false);
            }
            gameObjects[index].SetActive(true);
        } else if (gameObjects[index].activeInHierarchy) {
            if (checkSames && index == prevIndex) {
                
            } else {
                gameObjects[index].SetActive(false);
            }
        }
        prevIndex = index;
    }
}
