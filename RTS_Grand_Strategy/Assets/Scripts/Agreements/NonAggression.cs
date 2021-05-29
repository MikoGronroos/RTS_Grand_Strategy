using UnityEngine;

[CreateAssetMenu(menuName = "Agreement/NonAggression")]
public class NonAggression : Agreement
{
    public override void CreateAgreement(NationProfile country1, NationProfile country2)
    {
        base.CreateAgreement(country1, country2);
    }
}
