using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timeText;

    [SerializeField] private Button StopTimeButton;
    [SerializeField] private Button SlowTimeButton;
    [SerializeField] private Button DefaultTimeButton;
    [SerializeField] private Button TwoTimeButton;
    [SerializeField] private Button FiveTimeButton;
    [SerializeField] private Button TenTomeButton;

    public static Action<float> OnTimeChanged;

    private void Awake()
    {
        StopTimeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(0);
        });
        SlowTimeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(0.5f);
        });
        DefaultTimeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(1);
        });
        TwoTimeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(2);
        });
        FiveTimeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(5);
        });
        TenTomeButton.onClick.AddListener(() =>
        {
            OnTimeChanged.Invoke(10);
        });
    }

    private void OnEnable()
    {
        TimeSystem.OnHourChanged += OnHourChangedListener;
    }

    private void OnDisable()
    {
        TimeSystem.OnHourChanged -= OnHourChangedListener;
    }

    private void OnHourChangedListener(int time)
    {
        string currentTimeText = "";
        if (time < 10)
        {
            currentTimeText = $"0{time}:00";
        }
        else
        {
            currentTimeText = $"{time}:00";
        }
        timeText.text = currentTimeText;
    }

}
