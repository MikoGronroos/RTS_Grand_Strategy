using System;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{

    [SerializeField] private int hour;
    
    private float time = 0;
    private int previousHour = 0;

    public static Action OnDayChanged;
    public static Action<int> OnHourChanged;

    private void OnEnable()
    {
        TimeUI.OnTimeChanged += OnTimeChangedListener;
    }

    private void OnDisable()
    {
        TimeUI.OnTimeChanged -= OnTimeChangedListener;
    }

    private void Start()
    {
        OnHourChanged?.Invoke(hour);
    }

    private void Update()
    {
        time += 1 * Time.deltaTime;
        hour = (int)time;

        if (hour != previousHour)
        {
            OnHourChanged?.Invoke(hour);
            previousHour = hour;
        }

        if (hour > 24)
        {
            OnDayChanged?.Invoke();
            time = 0;
            hour = 0;
        }
    }

    private void OnTimeChangedListener(float time)
    {
        Time.timeScale = time;
    }

}
