using UnityEngine;

public class QueuedBuilding
{

    public QueuedBuilding(int BuilderId)
    {
        this.BuilderId = BuilderId;
        TimeSystem.OnDayChanged += OnDayPassed;
    }


    public BuildingType ThisType;

    public int CurrentBuildintTime;

    public int BuilderId;

    public void OnDayPassed()
    {
        CurrentBuildintTime++;

        if (CurrentBuildintTime >= ThisType.BuildingTime)
        {
            OnBuildingCompleted();
        }

    }

    private void OnBuildingCompleted()
    {
        TimeSystem.OnDayChanged -= OnDayPassed;
    }

}
