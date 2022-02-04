using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    [SerializeField] private string path;

    [SerializeField] private GameEvent onBuildingsLoadedEvent;

    private List<BuildingType> _allBuildings = new List<BuildingType>();

    #region Singleton

    private static BuildingSystem _instance;

    public static BuildingSystem Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        LoadBuildings();
    }

    private void LoadBuildings()
    {
        var buildings = Resources.LoadAll<BuildingType>(path);

        foreach (var building in buildings)
        {
            _allBuildings.Add(building);
        }

        onBuildingsLoadedEvent?.Invoke();

    }

    public BuildingType GetBuildingTypeWithName(string name)
    {
        foreach (var building in _allBuildings)
        {
            if (building.Name == name)
            {
                return building;
            }
        }
        return null;
    }

}
