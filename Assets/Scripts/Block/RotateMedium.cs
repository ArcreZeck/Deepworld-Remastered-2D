using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMedium : MonoBehaviour
{
    public float rots = 50f;

    void Update ()
    {
        transform.Rotate(0,0,rots*Time.deltaTime);
    }
}
