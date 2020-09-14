using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchMenu : MonoBehaviour
{

    public bool needsMusicTransition;
    public bool needsImageMusicTransition;
    public Animator musicAnimator;
    public float musicWaitTime;

    public void SwitchScene(string scene) {
        if (needsMusicTransition) {
            StartCoroutine(MusicSceneTransition(scene));
        } else {
            SceneManager.LoadScene(scene);
        }
    }

    public void SwitchSceneImage(string scene) {
        if (needsImageMusicTransition) {
            StartCoroutine(MusicSceneTransitionImage(scene));
        } else {
            SceneManager.LoadScene(scene);
        }
    }

    public void KillScene() {
        Application.Quit();
    }
    
    IEnumerator MusicSceneTransition(string scene) {
        musicAnimator.SetTrigger("fadeOut");
        yield return new WaitForSeconds(musicWaitTime);
        SceneManager.LoadScene(scene);
    }

    IEnumerator MusicSceneTransitionImage(string scene) {
        musicAnimator.SetTrigger("fadeOutImage");
        yield return new WaitForSeconds(musicWaitTime);
        SceneManager.LoadScene(scene);
    }
}
