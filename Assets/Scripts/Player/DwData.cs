using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwData : MonoBehaviour
{
    public int expTotal = 0;
    public int curLevel = 1;
    public int expToGo = 150;
    public int curCrowns = 50;

    public void SaveUserData() {
        SaveStatistics.SaveData(this);
    }

    public void LoadUserData() {
        DeepworldData data = SaveStatistics.LoadData();
        expTotal = data.expTotal;
        curLevel = data.curLevel;
        expToGo = data.expToGo;
        curCrowns = data.curCrowns;
    }
}
