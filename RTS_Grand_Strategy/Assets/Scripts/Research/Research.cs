using UnityEngine;

[CreateAssetMenu(menuName = "Research", fileName = "New Research")]
public class Research : ScriptableObject
{

    public string ResearchName;

    public ResearchFolder Folder;

    public Sprite Icon;

    public Vector2 Position;

    public int ResearchTimeInDays;

    public Research NextResearch;

    public Equipment ThisEquipment;

    private int _timeUntilComplete;

    private NationProfile _profile;

    public void StartResearch(NationProfile profile)
    {
        _profile = profile;
        _timeUntilComplete = ResearchTimeInDays;
        TimeSystem.OnDayChanged += NewDay;
    }

    public void NewDay()
    {
        _timeUntilComplete--;
        if (_timeUntilComplete <= 0)
        {
            TimeSystem.OnDayChanged -= NewDay;
            OnResearchComplete(_profile);
        }
    }

    public void Init(Research research)
    {
        ResearchName = research.ResearchName;
        Folder = research.Folder;
        Icon = research.Icon;
        Position = research.Position;
        ResearchTimeInDays = research.ResearchTimeInDays;
        NextResearch = research.NextResearch;
        ThisEquipment = research.ThisEquipment;
        _timeUntilComplete = research._timeUntilComplete;
    }

    public void OnResearchComplete(NationProfile profile)
    {
        profile.GetNationProduction().AddNewAvailableEquipment(ThisEquipment);
        profile.GetNationResearch().CompleteResearch(this);
    }
}
