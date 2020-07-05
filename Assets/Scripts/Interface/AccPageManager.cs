using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccPageManager : MonoBehaviour
{
    public GameObject[] accPages;

    public void ToggleButton(int index) {
        if (!accPages[index].activeInHierarchy) {
            foreach (GameObject item in accPages) {
                item.SetActive(false);
            }
            accPages[index].SetActive(true);
        } else if (accPages[index].activeInHierarchy) {
            accPages[index].SetActive(false);
        }
    }
}
