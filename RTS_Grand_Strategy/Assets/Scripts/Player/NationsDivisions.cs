using System.Collections.Generic;
using UnityEngine;

public class NationsDivisions : MonoBehaviour
{

    [SerializeField] private List<DivisionHolder> nationsDivisions = new List<DivisionHolder>();

    [SerializeField] private List<string> nationsIdsThatAreAllowedToMoveTo = new List<string>();

    public void AddToNationsDivisionsList(DivisionHolder division)
    {
        if (!nationsDivisions.Contains(division))
        {
            nationsDivisions.Add(division);
        }
    }

    public void AddNationIdToMovementList(string id)
    {
        if (!nationsIdsThatAreAllowedToMoveTo.Contains(id))
        {
            nationsIdsThatAreAllowedToMoveTo.Add(id);
        }
    }

    public bool IfProvinceIsAllowed(string id)
    {
        return nationsIdsThatAreAllowedToMoveTo.Contains(id);
    }

}
