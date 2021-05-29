using System.Collections.Generic;
using UnityEngine;

public class PoliticsSystem : MonoBehaviour
{

    [SerializeField] private List<Agreement> agreements = new List<Agreement>();

    [SerializeField] private List<Agreement> allAgreements = new List<Agreement>();

    [SerializeField] private GameEvent onPoliticsSystemActivated;

    private CountrySelection _countrySelection;
    private PlayersManager _playersManager;

    private void Awake()
    {
        _countrySelection = FindObjectOfType<CountrySelection>();
        _playersManager = FindObjectOfType<PlayersManager>();
    }

    private void Start()
    {

        GameEventHub.PoliticsSystemActivated.AmountOfAgreements = agreements.Count;

        onPoliticsSystemActivated?.Invoke();
    }

    public Agreement GetAgreementByID(int id)
    {
        for (int i = 0; i < agreements.Count; i++)
        {
            if (agreements[i].Id == id)
            {
                return agreements[i];
            }
        }
        return null;
    }

    public void CreateNewAgreement()
    {

        int id = GameEventHub.AcceptedAgreement.Id;

        var firstNation = _playersManager.GetNationProfile();
        var secondNation = NationProfileManager.GetNationProfile(_countrySelection.GetSelectedCountryID());

        Agreement newAgreement = (Agreement)ScriptableObject.CreateInstance(GetAgreementByID(id).name);
        newAgreement.CreateAgreement(firstNation, secondNation);
        newAgreement.Id = id;
        allAgreements.Add(newAgreement);
        firstNation.AddAgreement(newAgreement);
        secondNation.AddAgreement(newAgreement);

    }

}
