using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    bool musicPlaying = false;
    public AudioSource[] clips;
    int index;

    void Start() {
        index = 0;
    }

    void Update() {
        if (!musicPlaying) StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic() {
        musicPlaying = true;
        int prevIndex = index;
        while (index == prevIndex) {
            index = Random.Range(0, clips.Length - 1);
        }
        clips[index].Play();
        yield return new WaitUntil(() => clips[index].isPlaying);
        yield return new WaitUntil(() => !clips[index].isPlaying);
        musicPlaying = false;
    }
}
