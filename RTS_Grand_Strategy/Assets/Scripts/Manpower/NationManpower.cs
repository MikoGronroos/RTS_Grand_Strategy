using UnityEngine;

public class NationManpower : MonoBehaviour
{

    [SerializeField] private int coreManpower = 0;
    [SerializeField] private int noncoreManpower = 0;
    [SerializeField] private int monthlyPopulationGrowth = 0;

    [SerializeField] private float coreRecruitablePopulationFactor = 0.03f;
    [SerializeField] private float noncoreRecruitablePopulationFactor = 0.002f;
    [SerializeField] private int recruitablePopulation = 0;

    private NationProfile _profile;

    private void Awake()
    {
        _profile = GetComponent<NationProfile>();
    }

    public void OnStatesInitializedListener()
    {
        foreach (var state in _profile.GetNationStates())
        {
            if (state.StateCoreID.Equals(state.StateOwnerID))
            {
                coreManpower += state.Manpower;
            }else if (!state.StateCoreID.Equals(state.StateOwnerID))
            {
                noncoreManpower += state.Manpower;
            }
        }
        recruitablePopulation += (int)(coreManpower * coreRecruitablePopulationFactor);
    }
}
