using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTile : MonoBehaviour
{
    public GameObject Player;
    public float divRatio;
    public float negRatioX;
    public float negRatioY;

    void Update() {
        transform.position = new Vector3(Player.transform.position.x / divRatio - negRatioX, Player.transform.position.y / divRatio - negRatioY, transform.position.z);
    }
}
