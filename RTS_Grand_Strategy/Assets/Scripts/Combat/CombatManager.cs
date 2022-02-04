using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    [SerializeField] private List<Combat> onGoingCombats = new List<Combat>();

    #region Singleton

    private static CombatManager _instance;

    public static CombatManager Instance
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

    public void StartNewCombat(ProvinceHolder holder, DivisionHolder attackerHolder)
    {
        Combat newCombatInstance = new Combat();
        newCombatInstance.JoinCombatAsDefenderWithList(holder.GetProvinceDivisions().GetDivisionHolders());
        newCombatInstance.JoinCombatAsAttacker(attackerHolder);
        holder.GetProvinceCombat().SetOnGoingCombat(newCombatInstance);
        newCombatInstance.StartCombat();
        Debug.Log($"Created New Combat {newCombatInstance.ToString()}");
        AddOnGoingCombatToList(newCombatInstance);
    }

    private void AddOnGoingCombatToList(Combat combat)
    {
        if (!onGoingCombats.Contains(combat))
        {
            onGoingCombats.Add(combat);
        }
    }

    public void RemoveCombatFromListWithId(string id)
    {
        foreach (var combat in onGoingCombats)
        {
            if (combat.CombatId.Equals(id))
            {
                onGoingCombats.Remove(combat);
                return;
            }
        }
    }

}
