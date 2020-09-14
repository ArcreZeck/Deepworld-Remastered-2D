using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject wcDesktop;
    public GameObject wcMobile;
    public GameObject transitionDesktop;
    public GameObject transitionMobile;

    public void Awake() {
        #if (UNITY_IOS || UNITY_ANDROID)
            wcMobile.SetActive(true);
            wcDesktop.SetActive(false);
            transitionMobile.SetActive(true);
            transitionDesktop.SetActive(false);
        #else
            wcMobile.SetActive(false);
            wcDesktop.SetActive(true);
            transitionMobile.SetActive(false);
            transitionDesktop.SetActive(true);
        #endif
    }
}
