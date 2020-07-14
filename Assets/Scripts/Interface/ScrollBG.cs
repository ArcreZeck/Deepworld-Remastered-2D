using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public GameObject[] backgrounds;

    private void Update() {
        foreach (GameObject bg in backgrounds) {
            bg.transform.position = new Vector3(bg.transform.position.x - .5f, bg.transform.position.y, bg.transform.position.z);
            if (bg.transform.position.x <= -1024f) {
                bg.transform.position = new Vector3(5119f, bg.transform.position.y, bg.transform.position.z);
            }
        }
    }
}
