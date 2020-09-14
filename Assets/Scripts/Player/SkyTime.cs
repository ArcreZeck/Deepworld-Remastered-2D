using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTime : MonoBehaviour
{
    public float time;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        animator.Play("DayNight", 0, time);
    }
}
