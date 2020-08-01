﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigCont : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Space)) {
            anim.SetBool("isJumping", true);
        } else {
            anim.SetBool("isJumping", false);
        }
    }
}
