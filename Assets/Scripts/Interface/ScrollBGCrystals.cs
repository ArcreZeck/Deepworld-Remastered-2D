using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBGCrystals : MonoBehaviour
{
    public GameObject[] crystals;

    private void Update() {
        foreach (GameObject bg in crystals) {
            bg.transform.position = new Vector3(bg.transform.position.x - 1f, bg.transform.position.y, bg.transform.position.z);
            if (bg.transform.position.x <= -2048f) {
                bg.transform.position = new Vector3(4095f, bg.transform.position.y, bg.transform.position.z);
            }
        }
    }
}
