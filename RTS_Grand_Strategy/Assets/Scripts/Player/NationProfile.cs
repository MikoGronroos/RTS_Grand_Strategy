using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NationsDivisions))]
[RequireComponent(typeof(NationPolitics))]
[RequireComponent(typeof(NationStockpile))]
[RequireComponent(typeof(NationProduction))]
[RequireComponent(typeof(NationResearch))]
public class NationProfile : MonoBehaviour
{

    [SerializeField] private Country thisNation;

    [SerializeField] private bool localPlayer;

    [SerializeField] private List<ProvinceHolder> nationProvinces = new List<ProvinceHolder>();
    [SerializeField] private List<State> nationStates = new List<State>();

    [SerializeField] private GameEvent onWarSupportChanged;
    [SerializeField] private GameEvent onStabilityChanged;

    [SerializeField] private List<Agreement> nationAgreements = new List<Agreement>();

    [SerializeField] private List<string> wars = new List<string>();

    private NationsDivisions _nationsDivisions;
    private NationPolitics _politicalSystem;
    private NationProduction _nationProduction;
    private NationResearch _nationResearch;
    private NationStockpile _nationStockpile;

    public bool LocalPlayer
    {
        get
        {
            return localPlayer;
        }
        set
        {
            localPlayer = value;
            if (localPlayer)
            {
                PlayersManager.Instance.ChangeLocalPlayerNation(this);
            }
        }
    }

    private void Awake()
    {
        _nationStockpile = GetComponent<NationStockpile>();
        _nationResearch = GetComponent<NationResearch>();
        _nationsDivisions = GetComponent<NationsDivisions>();
        _politicalSystem = GetComponent<NationPolitics>();
        _nationProduction = GetComponent<NationProduction>();
    }

    public void SetStability(float value)
    {
        thisNation.Stability = value;
        if (localPlayer)
        {
            GameEventHub.StabilityChanged.value = thisNation.Stability;
            onStabilityChanged?.Invoke();
        }
    }

    public void SetWarSupport(float value)
    {
        thisNation.WarSupport = value;
        if (localPlayer)
        {
            GameEventHub.WarSupportChanged.value = thisNation.WarSupport;
            onWarSupportChanged?.Invoke();
        }
    }

    public void SetNation(Country country)
    {
        thisNation = country;
    }

    public void AddProvinceToNation(ProvinceHolder provinceHolder)
    {
        nationProvinces.Add(provinceHolder);
    }

    public void AddStateToNation(State state)
    {
        nationStates.Add(state);
    }

    public void AddAgreement(Agreement agreement)
    {
        nationAgreements.Add(agreement);
    }

    public void AddIdToWars(string id)
    {
        if (!wars.Contains(id))
        {
            wars.Add(id);
        }
    }

    public Country GetNation()
    {
        return thisNation;
    }

    public NationsDivisions GetNationsDivisions()
    {
        return _nationsDivisions;
    }

    public NationPolitics GetPoliticalSystem()
    {
        return _politicalSystem;
    }

    public NationProduction GetNationProduction()
    {
        return _nationProduction;
    }

    public NationResearch GetNationResearch()
    {
        return _nationResearch;
    }

    public NationStockpile GetNationStockpile()
    {
        return _nationStockpile;
    }

    public List<ProvinceHolder> GetNationProvinces()
    {
        return nationProvinces;
    }

    public List<State> GetNationStates()
    {
        return nationStates;
    }

    public bool CheckIfHasAgreement(string nationId, int id)
    {

        var profile = NationProfileManager.GetNationProfile(nationId);

        foreach (var agreement in nationAgreements)
        {
            if (agreement.Id == id)
            {
                if (agreement.nations[0] == profile || agreement.nations[1] == profile)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool HasWarWithNationID(string id)
    {
        return wars.Contains(id);
    }

}
