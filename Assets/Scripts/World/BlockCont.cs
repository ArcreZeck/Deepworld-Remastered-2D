using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCont : MonoBehaviour
{
    public int blockId;
    float blockHealth = 10f;
    float tempHealth = 10f;

    private void Start() {
        tempHealth = blockHealth;
    }

    public void DestroyBlock() {
        Destroy(gameObject);
    }

    private bool IsCloseToTag(string tag, float minimumDistance) {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < goWithTag.Length; ++i) {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
                return true;
        }
        return false;
    }

    private void Update() {
        // if (IsCloseToTag("Player", 10f)) {
        //     if (Input.GetMouseButton(0)) {
        //         tempHealth -= 0.1f;
        //         Debug.Log(tempHealth);
        //         if (tempHealth == 0f) {
        //             DestroyBlock();
        //         }
        //     }
        // }
    }
}
