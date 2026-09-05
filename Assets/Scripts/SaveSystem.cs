using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public float playerX, playerY, playerZ;
    public int timeMinutes;
}

public class SaveSystem : MonoBehaviour
{
    string path => Path.Combine(Application.persistentDataPath, "save.json");

    public void SaveGame(Transform player, TimeManager timeMgr) {
        SaveData d = new SaveData {
            playerX = player.position.x,
            playerY = player.position.y,
            playerZ = player.position.z,
            timeMinutes = timeMgr == null ? 0 : timeMgr.minutes
        };
        string json = JsonUtility.ToJson(d, true);
        File.WriteAllText(path, json);
        Debug.Log("Saved to " + path);
    }

    public void LoadGame(Transform player, TimeManager timeMgr) {
        if (!File.Exists(path)) { Debug.LogWarning("No save"); return; }
        string json = File.ReadAllText(path);
        SaveData d = JsonUtility.FromJson<SaveData>(json);
        player.position = new Vector3(d.playerX, d.playerY, d.playerZ);
        if (timeMgr != null) timeMgr.minutes = d.timeMinutes;
        Debug.Log("Loaded from " + path);
    }
}
