using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Province
{

    [SerializeField] private string provinceOwnerID;

    public int ProvinceStateID;

    public string ProvinceName;

    public int ProvinceId;

    public string ProvinceOwnerID {
        get
        {
            return provinceOwnerID;
        }
        set
        {
            provinceOwnerID = value;
        }
    }

    public string[] coreNationIds;

    public List<BuildingType> ProvinceBuildings = new List<BuildingType>();

    public bool ProvinceHasBuilding(BuildingType type)
    {
        return ProvinceBuildings.Contains(type);
    }

}
