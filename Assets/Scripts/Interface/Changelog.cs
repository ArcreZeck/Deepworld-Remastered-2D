using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changelog : MonoBehaviour
{
    public Animator changeAnim;

    public void ToggleChangelog() {
        changeAnim.SetBool("isOpened", !changeAnim.GetBool("isOpened"));
    }
}
