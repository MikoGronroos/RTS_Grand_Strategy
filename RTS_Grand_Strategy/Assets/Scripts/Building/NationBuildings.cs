using System.Collections.Generic;
using UnityEngine;

public class NationBuildings : MonoBehaviour
{

    [SerializeField] private List<QueuedBuilding> buildingQueue = new List<QueuedBuilding>();

    [SerializeField] private List<BuildingType> nationsAllowedBuildingTypes = new List<BuildingType>();

    public void AddBuildingToQueue(QueuedBuilding queuedBuilding)
    {
        buildingQueue.Add(queuedBuilding);
    }

    public void AddBuilding(BuildingType type)
    {
        if (!nationsAllowedBuildingTypes.Contains(type))
        {
            nationsAllowedBuildingTypes.Add(type);
        }
    }

    public List<BuildingType> GetNationsAllowedBuildings()
    {
        return nationsAllowedBuildingTypes;
    }

}
