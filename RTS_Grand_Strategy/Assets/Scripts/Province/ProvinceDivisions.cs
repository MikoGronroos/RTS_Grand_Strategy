using System.Collections.Generic;
using UnityEngine;

public class ProvinceDivisions : MonoBehaviour
{

    [SerializeField] private List<DivisionHolder> _divisionsOnTheProvince = new List<DivisionHolder>();

    public void AddDivisionToList(DivisionHolder division)
    {
        if (!_divisionsOnTheProvince.Contains(division))
        {
            _divisionsOnTheProvince.Add(division);
        }
    }

    public void RemoveDivisionFromList(DivisionHolder division)
    {
        if (_divisionsOnTheProvince.Contains(division))
        {
            _divisionsOnTheProvince.Remove(division);
        }
    }

    public IEnumerable<DivisionHolder> GetDivisionHolders()
    {
        return _divisionsOnTheProvince;
    }

    public DivisionHolder GetRandomDivisionFromList()
    {
        return _divisionsOnTheProvince[Random.Range(0, _divisionsOnTheProvince.Count)];
    }

    public bool HasDivision()
    {
        return _divisionsOnTheProvince.Count > 0;
    }

    public bool HasEnemyDivision(string nationId)
    {
        var nation = NationProfileManager.GetNationProfile(nationId);

        foreach (var division in _divisionsOnTheProvince)
        {
            if (nation.HasWarWithNationID(division.GetDivisionOwnerID()))
            {
                return true;
            }
        }
        return false;
    }

}
