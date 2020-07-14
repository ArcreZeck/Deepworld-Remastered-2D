using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveWorld {
    public static void SaveData(DwData data, string name) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves/" + name + ".dww";
        FileStream stream = new FileStream(path, FileMode.Create);
        DeepworldData saveData = new DeepworldData(data);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static DeepworldData LoadData(string name) {
        string path = Application.persistentDataPath + "/saves/" + name + ".dww";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DeepworldData data = formatter.Deserialize(stream) as DeepworldData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("DwWorld File Not Found In: " + path);
            return null;
        }
    }

    public static FileInfo[] FindWorlds() {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.dww");
        // foreach (FileInfo f in info) { }
        return info;
    }
}
