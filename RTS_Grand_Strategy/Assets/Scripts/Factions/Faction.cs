using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Faction
{

    [SerializeField] private string factionName;

    [SerializeField] private string factionLeader;

    [SerializeField] private List<Country> nationsInFaction = new List<Country>();

    public void SetFactionLeader(string id)
    {
        factionLeader = id;
    }

    public void AddNationToFaction(Country country)
    {
        nationsInFaction.Add(country);
    }

    public void SetFactionName(string name)
    {
        factionName = name;
    }

    public bool NationIsInFaction(Country country)
    {
        return nationsInFaction.Contains(country);
    }

    public bool NationIsFactionLeader(string id)
    {
        return factionLeader.Equals(id);
    }

    public string GetFactionName()
    {
        return factionName;
    }

}
