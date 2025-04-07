using System.IO;
using Character;
using UnityEngine;

public class SaveSystem
{
    private static string _savePath => Application.persistentDataPath + "/playerdata.json";

    public static void Save(CharacterData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_savePath, json);
    }

    public static CharacterData Load()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            return JsonUtility.FromJson<CharacterData>(json);
        }
        else
        {
            return null;
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(_savePath))
        {
            File.Delete(_savePath);
        }
    }
}