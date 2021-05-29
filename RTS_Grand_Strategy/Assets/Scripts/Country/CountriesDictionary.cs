using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CountriesDictionary : MonoBehaviour
{

    [SerializeField] private string path;

    [SerializeField] private List<Country> allCountries = new List<Country>();

    [SerializeField] private GameEvent onCountriesLoaded;
        
    private void Awake()
    {
        LoadCountries();
    }

    private void LoadCountries()
    {
        TextAsset[] countryFiles = Resources.LoadAll<TextAsset>(path);

        foreach (TextAsset file in countryFiles)
        {
            Country country = JsonUtility.FromJson<Country>(file.text);
            if (country.CountryFlagPath != "")
            {
                Texture tex = Resources.Load<Texture>(country.CountryFlagPath);
                country.CountryFlag = tex;
            }
            allCountries.Add(country);
        }

        GameEventHub.CountriesLoaded.Countries = allCountries;

        onCountriesLoaded?.Invoke();
    }
}
