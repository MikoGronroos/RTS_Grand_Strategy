using System;
using UnityEngine;

public class ProvinceSelection : MonoBehaviour
{

    [SerializeField] private Province selectedProvince;

    [Header("GameEvents")]
    [SerializeField] private GameEvent onProvinceSelected;

    private CountrySelection _countrySelection;

    private void Awake()
    {
        _countrySelection = FindObjectOfType<CountrySelection>();
    }

    public void SetSelectedArea(Province province, SpriteRenderer renderer)
    {
        _countrySelection.SetSelectedCountry(NationProfileManager.GetNationProfile(province.ProvinceOwnerID).GetNation());
        if (selectedProvince != province)
        {
            selectedProvince = province;
        }
        GameEventHub.ProvinceSelected.SelectedProfile = NationProfileManager.GetNationProfile(province.ProvinceOwnerID);
        GameEventHub.ProvinceSelected.ForeignClaimsProfile = NationProfileManager.GetNationProfile(StatesDictionary.GetStateFromDictionary(province.ProvinceStateID).StateCoreID);
        GameEventHub.ProvinceSelected.SelectedProvince = selectedProvince;
        GameEventHub.ProvinceSelected.Renderer = renderer;

        onProvinceSelected?.Invoke();
    }
}
