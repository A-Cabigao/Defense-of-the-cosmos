using UnityEngine;
using UnityEngine.Events;

public class GameTimer : Singleton<GameTimer>
{
    public UnityEvent<int> OnMinutePass;
    public float TimeSinceGameStart { get; private set; } = 0f;
    public float RunningGameTime { get; private set; } = 0f;
    public int CurrentMinute { get; private set; } = 0;
    private int PastMinute;
    public bool IsGameTimerStarted { get; private set; } = false;
    public bool IsGameTimerPaused { get; private set; } = false;

    private void Start()
    {
        if (Application.isEditor)        
            IsGameTimerStarted = true;

        PastMinute = CurrentMinute;
    }

    private void OnDestroy()
    {
        OnMinutePass?.RemoveAllListeners();
    }

    private void Update()
    {
        UpdateTimers();
    }

    public void StartGameTimer()
    {
        if (IsGameTimerStarted)
        { return; }
        IsGameTimerStarted = true;
    }

    public void PauseGameTimer()
    {
        if (IsGameTimerPaused)
        { return; }
        IsGameTimerPaused = true;
    }

    public void UnpauseGameTimer()
    {
        if (!IsGameTimerPaused)
        { return; }
        IsGameTimerPaused = false;
    }

    void UpdateTimers()
    {
        TimeSinceGameStart += Time.deltaTime;

        if (!IsGameTimerPaused)
        {
            RunningGameTime += Time.deltaTime;
        }

        UpdateMinute();        
    }

    void UpdateMinute()
    {
        CurrentMinute = Mathf.FloorToInt(RunningGameTime / 60f);

        if(CurrentMinute > PastMinute)
        {
            OnMinutePass?.Invoke(CurrentMinute);
            PastMinute = CurrentMinute;
        }
    }
}
