using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    [Tooltip("How many in-game minutes pass per real second")]
    public float minutesPerRealSecond = 1f; // 1 real second => X game minutes
    [HideInInspector]
    public int minutes = 420; // start at 7:00 (7*60)

    public event Action<int,int> OnTimeChanged;
    public event Action<float> OnMinutePassed; // deltaMinutes

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update() {
        float deltaMinutes = Time.deltaTime * minutesPerRealSecond;
        if (deltaMinutes <= 0) return;
        minutes += Mathf.FloorToInt(deltaMinutes);
        minutes = minutes % (24 * 60);
        int h = minutes / 60;
        int m = minutes % 60;
        OnMinutePassed?.Invoke(deltaMinutes);
        OnTimeChanged?.Invoke(h, m);
    }

    public string GetTimeString() {
        int h = minutes / 60;
        int m = minutes % 60;
        return $"{h:D2}:{m:D2}";
    }

    public void AdvanceMinutes(int add) {
        minutes = (minutes + add) % (24 * 60);
    }
}
