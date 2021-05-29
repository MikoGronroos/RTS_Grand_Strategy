using System.Collections.Generic;
using UnityEngine;

public class NationsDivisions : MonoBehaviour
{

    [SerializeField] private List<DivisionHolder> nationsDivisions = new List<DivisionHolder>();

    [SerializeField] private List<ProvinceHolder> nationsAllowedProvinces = new List<ProvinceHolder>();

    public void AddToNationsDivisionsList(DivisionHolder division)
    {
        if (!nationsDivisions.Contains(division))
        {
            nationsDivisions.Add(division);
        }
    }

    public void AddAllowedProvince(ProvinceHolder holder)
    {
        nationsAllowedProvinces.Add(holder);
    }

    public void AddListToAllowedProvinces(List<ProvinceHolder> holder)
    {
        foreach (var province in holder)
        {
            nationsAllowedProvinces.Add(province);
        }
    }

    public bool IfProvinceIsAllowed(ProvinceHolder holder)
    {
        return nationsAllowedProvinces.Contains(holder);
    }

}
