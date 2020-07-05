using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource[] clips;
    public void PlayButtonSound(int index) {
        clips[index].Play();
    }
}
