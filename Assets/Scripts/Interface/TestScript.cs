using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
    public Renderer objectRenderer;

    void Update() {
		if (objectRenderer.IsVisibleFrom(Camera.main)) {
            Debug.Log("Visible");
        } else {
            Debug.Log("Not visible");
        }
    }
}
