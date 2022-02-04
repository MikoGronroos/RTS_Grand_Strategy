using UnityEngine;

[CreateAssetMenu(menuName = "Agreement/DeclareWar")]
public class DeclareWar : Agreement
{
    public override void CreateAgreement(NationProfile country1, NationProfile country2)
    {
        country1.AddIdToWars(country2.GetNation().CountryID);
        country2.AddIdToWars(country1.GetNation().CountryID);
        country1.GetNationsDivisions().AddNationIdToMovementList(country2.GetNation().CountryID);
        country2.GetNationsDivisions().AddNationIdToMovementList(country1.GetNation().CountryID);
        base.CreateAgreement(country1, country2);
    }
}
