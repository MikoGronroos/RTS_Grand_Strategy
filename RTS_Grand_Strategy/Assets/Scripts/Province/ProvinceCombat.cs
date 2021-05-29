using UnityEngine;

public class ProvinceCombat : MonoBehaviour
{

    private Combat onGoingCombat;

    public void SetOnGoingCombat(Combat combat)
    {
        onGoingCombat = combat;
    }

    public Combat GetOngoingCombat()
    {
        return onGoingCombat;
    }

    public bool ProvinceIsInCombat()
    {
        return onGoingCombat != null;
    }

}
