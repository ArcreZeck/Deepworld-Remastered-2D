using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButton : MonoBehaviour
{
    public float iosSize = 1f;

    public void logRes() {
            Debug.Log(Screen.currentResolution);
            gameObject.transform.localScale = new Vector3(iosSize, iosSize, 1f);
    }
}
