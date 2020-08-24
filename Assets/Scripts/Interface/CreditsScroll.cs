using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 0.5f;
    int ending = 0;
    public AudioSource audioObject;

    private void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        if (transform.position.y >= 200) {
            if (ending == 0) {
                ending++;
                ExecuteAfterTime(1);
            }
        }
    }

    private void OnMouseDown() {
        ExecuteAfterTime(1);
    }

    public IEnumerator ExecuteAfterTime(float time) {
        StartFade(audioObject, 1, 0);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume) {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration) {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
