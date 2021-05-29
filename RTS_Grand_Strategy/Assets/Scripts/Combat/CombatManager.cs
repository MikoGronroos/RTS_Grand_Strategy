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
        Combat combatInstance = new Combat();
        combatInstance.JoinCombatAsDefenderWithList(holder.GetProvinceDivisions().GetDivisionHolders());
        combatInstance.JoinCombatAsAttacker(attackerHolder);
        holder.GetProvinceCombat().SetOnGoingCombat(combatInstance);
        AddOnGoingCombatToList(combatInstance);
    }

    public void AddOnGoingCombatToList(Combat combat)
    {
        if (!onGoingCombats.Contains(combat))
        {
            onGoingCombats.Add(combat);
        }
    }
}
