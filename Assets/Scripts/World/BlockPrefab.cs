using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPrefab : MonoBehaviour
{
    void OnMouseDown() {
        Destroy(gameObject);
    }
}
