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
            Debug.Log("Getting new Index..");
            index = Random.Range(0, clips.Length - 1);
        }
        StartCoroutine(playSong());
    }

    IEnumerator playSong() {
        Debug.Log("Running playSong()");
        clips[index].Play();
        Debug.Log("Playing Song...");
        yield return new WaitForSeconds(clips[index].clip.length);
        prevIndex = index;
        while (index == prevIndex) {
            Debug.Log("Getting new Index..");
            index = Random.Range(0, clips.Length - 1);
        }
        StartCoroutine(playSong());
    }
}
