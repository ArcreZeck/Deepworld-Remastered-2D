using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour
{
    public Material shaderMat;
    public Sprite shieldOffSprite;
    public Sprite shieldOnSprite;
    public GameObject shield;
    private float fade = 0;
    private bool isDissolving = false;
    private bool shieldOn = false;

    public void toggleShield() {
        isDissolving = true;
        shieldOn = !shieldOn;
        if (shieldOn) {
            shield.GetComponent<Image>().sprite = shieldOnSprite;
        } else {
            shield.GetComponent<Image>().sprite = shieldOffSprite; 
        }
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
