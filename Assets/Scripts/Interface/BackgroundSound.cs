using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioSource[] clips;
    int index = 0;
    int prevIndex = 0;

    void Start() {
        while (index == prevIndex) {
            index = Random.Range(0, clips.Length - 1);
        }
        StartCoroutine(playSong());
    }

    IEnumerator playSong() {
        clips[index].Play();
        yield return new WaitForSeconds(clips[index].clip.length);
        prevIndex = index;
        while (index == prevIndex) {
            index = Random.Range(0, clips.Length - 1);
        }
        StartCoroutine(playSong());
    }
}
