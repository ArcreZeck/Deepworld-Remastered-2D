using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwData : MonoBehaviour
{
    public int userData1 = 0;
    public int userData2 = 1;
    public int userData3 = 150;
    public int userData4 = 200;

    public void SaveUserData() {
        SaveStatistics.SaveData(this);
    }

    public void LoadUserData() {
        DeepworldData data = SaveStatistics.LoadData();
        userData1 = data.userData1;
        userData2 = data.userData2;
        userData3 = data.userData3;
        userData4 = data.userData4;
    }
}
