using UnityEngine;

[System.Serializable]
public abstract class Agreement : ScriptableObject
{

    public int Id;

    public NationProfile[] nations = new NationProfile[2];

    public virtual void CreateAgreement(NationProfile country1, NationProfile country2)
    {
        nations[0] = country1;
        nations[1] = country2;
    }
}
