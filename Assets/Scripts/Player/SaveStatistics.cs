using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveStatistics {
    public static void SaveData(DwData data) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/statistics.dwd";
        FileStream stream = new FileStream(path, FileMode.Create);
        DeepworldData saveData = new DeepworldData(data);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static DeepworldData LoadData() {
        string path = Application.persistentDataPath + "/statistics.dwd";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DeepworldData data = formatter.Deserialize(stream) as DeepworldData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("DwData File Not Found in: " + path);
            return null;
        }
    }
}
