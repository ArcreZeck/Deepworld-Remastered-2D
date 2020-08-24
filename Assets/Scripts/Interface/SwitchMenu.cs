using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchMenu : MonoBehaviour
{
    Scene currentScene;
    string sceneName;

    public bool needsMusicTransition;
    public Animator musicAnimator;
    public float musicWaitTime;

    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void SwitchScene(string scene) {
        if (needsMusicTransition) {
            StartCoroutine(MusicSceneTransition(scene));
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
}
