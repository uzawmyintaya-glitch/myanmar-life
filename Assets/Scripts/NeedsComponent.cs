using System.Collections.Generic;
using UnityEngine;

public class NeedsComponent : MonoBehaviour
{
    public List<Need> needs = new List<Need>();

    void OnEnable() {
        if (TimeManager.Instance != null) TimeManager.Instance.OnMinutePassed += OnMinute;
    }
    void OnDisable() {
        if (TimeManager.Instance != null) TimeManager.Instance.OnMinutePassed -= OnMinute;
    }

    void OnMinute(float deltaMinutes) {
        foreach (var n in needs) n.Tick(deltaMinutes);
    }

    public Need GetNeed(string id) {
        return needs.Find(x => x.id == id);
    }
}
