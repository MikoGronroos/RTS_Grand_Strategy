using UnityEngine;

public class NationStartBuildings : MonoBehaviour
{   

    public void SetNationStartBuildings()
    {
        foreach (var profile in NationProfileManager.Instance.GetAllProfiles())
        {
            foreach (var building in profile.GetNation().NationStartingBuildingTypes)
            {
                profile.GetNationBuildings().AddBuilding(BuildingSystem.Instance.GetBuildingTypeWithName(building));
            }
        }
    }

}
