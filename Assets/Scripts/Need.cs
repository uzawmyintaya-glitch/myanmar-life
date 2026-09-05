using UnityEngine;

[System.Serializable]
public class Need {
    public string id = "hunger";
    [Range(0,100)] public float value = 100f;
    [Tooltip("Amount of need decay per in-game minute")]
    public float decayPerMinute = 0.5f; // per in-game minute

    public void Tick(float minutes) {
        value = Mathf.Clamp(value - decayPerMinute * minutes, 0f, 100f);
    }

    public void Modify(float delta) {
        value = Mathf.Clamp(value + delta, 0f, 100f);
    }
}
