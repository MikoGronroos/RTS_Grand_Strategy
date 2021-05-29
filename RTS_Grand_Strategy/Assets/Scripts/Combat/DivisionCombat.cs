using UnityEngine;

public class DivisionCombat : MonoBehaviour
{

    private DivisionHolder _holder;

    public bool IsInCombat { get; set; }

    private void Awake()
    {
        _holder = GetComponent<DivisionHolder>();
    }

    public void CombatCheck(ProvinceHolder holder)
    {
        if (!holder.GetProvinceCombat().ProvinceIsInCombat())
        {
            CombatManager.Instance.StartNewCombat(holder, _holder);
            IsInCombat = true;
        }
        else
        {
            if (holder.GetProvinceCombat().GetOngoingCombat().IsAggressor(_holder.GetDivisionOwnerID()))
            {
                holder.GetProvinceCombat().GetOngoingCombat().JoinCombatAsAttacker(_holder);
                IsInCombat = true;
            }
            else if (holder.GetProvinceCombat().GetOngoingCombat().IsDefender(_holder.GetDivisionOwnerID()))
            {
                holder.GetProvinceCombat().GetOngoingCombat().JoinCombatAsDefender(_holder);
                IsInCombat = true;
            }
        }
    }

    public void LeaveCombat(ProvinceHolder holder)
    {
        if (holder.GetProvinceCombat().GetOngoingCombat().IsAggressor(_holder.GetDivisionOwnerID()))
        {
            holder.GetProvinceCombat().GetOngoingCombat().RetreatFromAttackers(_holder);
        }
        else if (holder.GetProvinceCombat().GetOngoingCombat().IsDefender(_holder.GetDivisionOwnerID()))
        {
            holder.GetProvinceCombat().GetOngoingCombat().RetreatFromDefenders(_holder);
        }
        IsInCombat = false;
    }

    public void ConquerNewProvince(ProvinceHolder holder)
    {
        ConquerProvince.Conquer(holder, _holder.GetDivisionOwnerID());
    }

}
