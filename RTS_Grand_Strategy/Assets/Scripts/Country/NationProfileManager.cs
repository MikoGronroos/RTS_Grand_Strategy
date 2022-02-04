using System.Collections.Generic;
using UnityEngine;

public class NationProfileManager : MonoBehaviour
{

    [SerializeField] private GameObject nationProfilePrefab;

    [SerializeField] private GameEvent onNationsLoaded;

    private static List<NationProfile> nationProfiles = new List<NationProfile>();

    #region Singleton

    private static NationProfileManager _instance;

    public static NationProfileManager Instance { get { return _instance; } }

    #endregion

    private void Awake()
    {
        _instance = this;
    }

    public void OnCountriesLoadedListener()
    {

        List<Country> nationsList = GameEventHub.CountriesLoaded.Countries;

        GameObject nationParent = new GameObject();

        nationParent.name = "nationProfileParent";

        nationParent.transform.position = Vector3.zero;

        foreach (var nation in nationsList)
        {
            GameObject nationObject = Instantiate(nationProfilePrefab);
            NationProfile profile = nationObject.GetComponent<NationProfile>();
            profile.SetNation(nation);
            profile.name = $"{nation.CountryID} profile";
            profile.GetNationsDivisions().AddNationIdToMovementList(profile.GetNation().CountryID);
            nationObject.transform.SetParent(nationParent.transform);
            nationProfiles.Add(profile);
        }

        onNationsLoaded?.Invoke();
    }

    public static NationProfile GetNationProfile(string id)
    {

        if (id == "")
        {
            Debug.Log("There was no id given");
            return null;
        }
        for (int i = 0; i < nationProfiles.Count; i++)
        {
            if (nationProfiles[i].GetNation().CountryID == id)
            {
                return nationProfiles[i];
            }
        }
        Debug.Log("The given id wasnt in the list");
        return null;
    }

    public List<NationProfile> GetAllProfiles()
    {
        return nationProfiles;
    }

}
