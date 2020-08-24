using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdButtonManager : MonoBehaviour
{
    public void playRewardableAd() {
        if (Advertisement.IsReady("rewardedVideo")) {
            Debug.Log("Advertisement Is Ready");
            Advertisement.Show("rewardedVideo");
        }
    }
}
