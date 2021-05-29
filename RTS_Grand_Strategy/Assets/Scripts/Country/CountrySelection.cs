using UnityEngine;

public class CountrySelection : MonoBehaviour
{

    [SerializeField] private Country selectedCountry;

    public void SetSelectedCountry(Country country)
    {
        selectedCountry = country;
    }

    public string GetSelectedCountryID()
    {
        return selectedCountry.CountryID;
    }

}
