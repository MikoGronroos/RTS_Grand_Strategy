using UnityEngine;

[System.Serializable]
public class Country
{

    public Country(string countryID, float r, float g, float b)
    {
        CountryID = countryID;
        ThisCountryColor = new CountryColor(r,g,b);
    }

    //Country ID is three character id. Example England = ENG
    public string CountryID;

    public CountryColor ThisCountryColor;

    public string CountryFlagPath;

    public Texture CountryFlag;

    public float WarSupport;

    public float Stability;

    public int ResearchSlots;

    public string[] NationStartingResearch;

    public string[] NationStartingBuildingTypes;

    public Color GetCountryColor()
    {
        return new Color(ThisCountryColor.R / 255.0f, ThisCountryColor.G / 255.0f, ThisCountryColor.B / 255.0f, 1);
    }

}
