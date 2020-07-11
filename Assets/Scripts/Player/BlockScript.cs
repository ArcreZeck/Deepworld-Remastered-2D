using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    void Update() {
        if (gameObject.GetComponent<SpriteRenderer>().isVisible) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        } else {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
