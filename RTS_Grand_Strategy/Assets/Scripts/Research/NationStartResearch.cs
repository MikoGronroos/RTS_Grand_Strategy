using UnityEngine;

public class NationStartResearch : MonoBehaviour
{
    public void StartResearchForNations()
    {
        foreach (var profile in NationProfileManager.Instance.GetAllProfiles())
        {
            foreach (var research in profile.GetNation().NationStartingResearch)
            {
                ResearchSystem.Instance.GetResearchFromAllResearch(research).OnResearchComplete(profile);
            }
        }
    }

}
