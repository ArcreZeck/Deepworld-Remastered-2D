using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTime : MonoBehaviour
{
    void Start() {
        ParticleSystem ptcs = gameObject.GetComponent<ParticleSystem>();
        ptcs.Simulate(500);
        ptcs.Play();
    }
}
