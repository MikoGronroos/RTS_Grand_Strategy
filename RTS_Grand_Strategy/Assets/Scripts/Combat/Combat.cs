using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Combat
{

    [SerializeField] private string combatName;

    [SerializeField] private List<DivisionHolder> attackerParticipants = new List<DivisionHolder>();
    [SerializeField] private List<DivisionHolder> defenderParticipants = new List<DivisionHolder>();

    [SerializeField] private List<DivisionHolder> attackerReserves = new List<DivisionHolder>();
    [SerializeField] private List<DivisionHolder> defenderReserves = new List<DivisionHolder>();

    [SerializeField] private float averageDefenderOrg;
    [SerializeField] private float averageAttackerOrg;

    [SerializeField] private float averageDefenderDamage;
    [SerializeField] private float averageAttackerDamage;

    private HashSet<string> attackerNationIds = new HashSet<string>();
    private HashSet<string> defenderNationIds = new HashSet<string>();

    public string CombatId { get; set; }

    public Combat()
    {
        CombatId = Guid.NewGuid().ToString();
    }

    #region Combat Start And Stop

    public void StartCombat()
    {
        TimeSystem.OnDayChanged += CombatDay;
        averageDefenderOrg = CombatCalculations.AverageOrganization(defenderParticipants);
        averageAttackerOrg = CombatCalculations.AverageOrganization(attackerParticipants);

        averageDefenderDamage = CombatCalculations.AverageDamage(defenderParticipants);
        averageAttackerDamage = CombatCalculations.AverageDamage(attackerParticipants);
    }

    public void StopCombat()
    {
        TimeSystem.OnDayChanged -= CombatDay;
        CombatManager.Instance.RemoveCombatFromListWithId(CombatId);
    }

    #endregion

    #region Combat

    private void CombatDay()
    {

        Debug.Log($"attacker organization is {averageAttackerOrg}");
        Debug.Log($"defender organization is {averageDefenderOrg}");

        averageAttackerOrg -= averageDefenderDamage;
        averageDefenderOrg -= averageAttackerDamage;

        if (CheckIfCombatEnds())
        {
            StopCombat();
        }

    }

    private bool CheckIfCombatEnds()
    {
        if (attackerParticipants.Count == 0 || defenderParticipants.Count == 0)
        {
            return true;
        }
        if (averageDefenderOrg == 0 || averageAttackerOrg == 0)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region Join Or Leave

    public void JoinCombatAsAttacker(DivisionHolder holder)
    {
        if (!attackerParticipants.Contains(holder))
        {
            attackerParticipants.Add(holder);
        }
        attackerNationIds.Add(holder.GetDivisionOwnerID());
    }

    public void JoinCombatAsDefender(DivisionHolder holder)
    {
        if (!defenderParticipants.Contains(holder))
        {
            defenderParticipants.Add(holder);
        }
        defenderNationIds.Add(holder.GetDivisionOwnerID());
    }

    public void JoinCombatAsDefenderWithList(IEnumerable<DivisionHolder> holders)
    {
        foreach (var holder in holders)
        {
            defenderParticipants.Add(holder);
            defenderNationIds.Add(holder.GetDivisionOwnerID());
        }
    }

    public void JoinReservesAsAttacker(DivisionHolder holder)
    {
        if (!attackerReserves.Contains(holder))
        {
            attackerReserves.Add(holder);
        }
    }

    public void JoinReservesAsDefender(DivisionHolder holder)
    {
        if (!defenderReserves.Contains(holder))
        {
            defenderReserves.Add(holder);
        }
    }

    public void RetreatFromAttackers(DivisionHolder holder)
    {
        if (attackerParticipants.Contains(holder))
        {
            attackerParticipants.Remove(holder);
            CheckIfCombatEnds();
        }
    }

    public void RetreatFromDefenders(DivisionHolder holder)
    {
        if (defenderParticipants.Contains(holder))
        {
            defenderParticipants.Remove(holder);
            CheckIfCombatEnds();
        }
    }

    public void LeaveFromReserves(DivisionHolder holder)
    {
        if (!attackerReserves.Contains(holder))
        {
            attackerReserves.Add(holder);
        }
    }

    #endregion

    public void SetCombatName(string name)
    {
        combatName = name;
    }

    public bool IsAggressor(string id)
    {
        return attackerNationIds.Contains(id);
    }

    public bool IsDefender(string id)
    {
        return defenderNationIds.Contains(id);
    }

    public string ToString()
    {
        return $"{CombatId}";
    }

}
