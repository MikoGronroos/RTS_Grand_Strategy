using System;
using UnityEngine;

public class NationPolitics : MonoBehaviour
{

    [SerializeField] private float currentPoliticalPower;

    [SerializeField] private float politicalPowerGain = 2; //Default = 1

    [SerializeField] private GameEvent onPoliticalPowerChanged;

    [SerializeField] private NationProfile _profile;

    private void Start()
    {
        _profile = GetComponent<NationProfile>();
    }

    private void OnEnable()
    {
        TimeSystem.OnDayChanged += IncrementPoliticalPower;
    }

    private void OnDisable()
    {
        TimeSystem.OnDayChanged -= IncrementPoliticalPower;
    }


    public void SetPoliticalPower(float power)
    {
        currentPoliticalPower = power;
    }

    private void IncrementPoliticalPower()
    {
        currentPoliticalPower = _profile.GetNation().Stability >= 62 ? (float)Math.Round(currentPoliticalPower += (float)(politicalPowerGain * 1.015), 3)
            : (float)Math.Round(currentPoliticalPower += (float)(politicalPowerGain * 0.73), 3);
        if (_profile.LocalPlayer)
        {
            GameEventHub.PoliticalPowerChanged.value = currentPoliticalPower;
            onPoliticalPowerChanged?.Invoke();
        }
    }

    public float GetPoliticalPower()
    {
        return currentPoliticalPower;
    }

}
