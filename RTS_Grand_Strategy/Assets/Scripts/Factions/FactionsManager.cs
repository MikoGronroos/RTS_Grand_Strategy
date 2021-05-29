using System.Collections.Generic;
using UnityEngine;

public class FactionsManager : MonoBehaviour
{

    [SerializeField] private List<Faction> factions = new List<Faction>();

    public void AddFactionToList(Faction faction)
    {
        factions.Add(faction);
    }

    public Faction GetFactionWithCountry(Country country)
    {
        for (int i = 0; i < factions.Count; i++)
        {
            if (factions[i].NationIsInFaction(country))
            {
                return factions[i];
            }
        }
        return null;
    }

}
