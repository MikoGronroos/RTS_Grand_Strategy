using System.Collections.Generic;
using UnityEngine;

public class UI_BuildingMenu : MonoBehaviour
{

    [SerializeField] private GameObject buildingTypeUIPrefab;

    [SerializeField] private Transform uiParent;

    private List<GameObject> currentBuildingTypes = new List<GameObject>();

    public void DrawBuildingTypes()
    {

        foreach (var building in PlayersManager.Instance.GetLocalNationProfile().GetNationBuildings().GetNationsAllowedBuildings())
        {
            GameObject buildingGameObject = Instantiate(buildingTypeUIPrefab, uiParent);
            currentBuildingTypes.Add(buildingGameObject);
        }

    }

    public void ClearTheUI()
    {
        foreach (var building in currentBuildingTypes)
        {
            Destroy(building);
        }
        currentBuildingTypes.Clear();
    }
}