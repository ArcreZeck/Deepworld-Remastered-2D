using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeepworldData
{
    public int userData1;
    public int userData2;
    public int userData3;
    public int userData4;

    public DeepworldData(DwData data) {
        userData1 = data.userData1; // Experience At Current level
        userData2 = data.userData2; // Current Level Entirely
        userData3 = data.userData3; // Experience Needed To Go To Next Level
        userData4 = data.userData4; // Current Crowns
    }
}
