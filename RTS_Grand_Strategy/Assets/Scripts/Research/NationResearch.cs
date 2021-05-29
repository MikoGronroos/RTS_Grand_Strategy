using System.Collections.Generic;
using UnityEngine;

public class NationResearch : MonoBehaviour
{

    [SerializeField] private List<Research> nationsResearch = new List<Research>();

    [SerializeField] private List<Research> completedResearch = new List<Research>();

    private NationProfile _profile;

    private void Awake()
    {
        _profile = GetComponent<NationProfile>();
    }

    public int GetAmountOfResearchSlots()
    {
        return _profile.GetNation().ResearchSlots;
    }

    public void AddToNationResearch(Research research)
    {
        var instance = ScriptableObject.CreateInstance<Research>();
        instance.Init(research);
        nationsResearch.Add(instance);
        instance.StartResearch(_profile);
    }

    public void CompleteResearch(Research instance)
    {
        nationsResearch.Remove(instance);
        completedResearch.Add(instance);
    }

}
