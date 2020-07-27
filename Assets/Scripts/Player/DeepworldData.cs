using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeepworldData
{
    public int expTotal;
    public int curLevel;
    public int expToGo;
    public int curCrowns;
    public int[] curItems;

    public DeepworldData(DwData data) {
        expTotal = data.expTotal; // Experience At Current level
        curLevel = data.curLevel; // Current Level Entirely
        expToGo = data.expToGo; // Experience Needed To Go To Next Level
        curCrowns = data.curCrowns; // Current Crowns
        curItems = data.curItems; // Current Items
    }
}
