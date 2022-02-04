using UnityEngine;

[CreateAssetMenu(menuName = "Agreement/AskForMilitaryAccess")]
public class AskForMilitaryAccess : Agreement
{

    public override void CreateAgreement(NationProfile country1, NationProfile country2)
    {
        base.CreateAgreement(country1, country2);
        country1.GetNationsDivisions().AddNationIdToMovementList(country2.GetNation().CountryID);
    }

}
