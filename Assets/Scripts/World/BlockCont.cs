using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCont : MonoBehaviour {
    public int blockId;
    float blockHealth = 10f;
    float tempHealth;
    private SpriteRenderer spriteRenderer;

    private void Start () {
        tempHealth = blockHealth;
        GameObject child = gameObject.transform.GetChild (0).gameObject;
        spriteRenderer = child.GetComponent<SpriteRenderer> ();
    }

    void OnMouseDown () {
        if (tempHealth == 10f) {
            tempHealth -= 3f;
            spriteRenderer.sprite = Resources.Load<Sprite> ("Effects/crack1");
        } else if (tempHealth == 7f) {
            tempHealth -= 3f;
            spriteRenderer.sprite = Resources.Load<Sprite> ("Effects/crack2");
        } else if (tempHealth == 4f) {
            tempHealth -= 4f;
            spriteRenderer.sprite = Resources.Load<Sprite> ("Effects/crack3");
        } else if (tempHealth <= 0f) {
            Destroy (gameObject);
        }
    }

    private bool IsCloseToTag (string tag, float minimumDistance) {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag (tag);
        for (int i = 0; i < goWithTag.Length; ++i) {
            if (Vector3.Distance (transform.position, goWithTag[i].transform.position) <= minimumDistance) {
                return true;
            }
        }
        return false;
    }
}