using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Material shaderMat;
    private float fade = 0;
    private bool isDissolving = false;
    private bool shieldOn = false;

    public void toggleShield() {
        isDissolving = true;
        shieldOn = !shieldOn;
    }

    private void Update() {
        if (isDissolving) {
            if (!shieldOn) {
                fade -= Time.deltaTime;
            } else {
                fade += Time.deltaTime;
            }
        }
        fade = Mathf.Clamp(fade, 0, 1);
        shaderMat.SetFloat("_CurFade", fade);
    }
}
