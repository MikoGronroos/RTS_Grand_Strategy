using System.Collections.Generic;
using UnityEngine;

public class StateFileManager : MonoBehaviour
{

    [SerializeField] private string path;

    [SerializeField] private GameEvent onStatesInitialized;

    public void LoadProvinceData()
    {
        TextAsset[] stateFiles = Resources.LoadAll<TextAsset>(path);

        List<State> states = new List<State>();

        foreach (TextAsset file in stateFiles)
        {
            State state = JsonUtility.FromJson<State>(file.text);
            states.Add(state);
            StatesDictionary.AddToDictionary(state);
        }
        InitializeStates(states);
    }

    private void InitializeStates(IEnumerable<State> states)
    {
        foreach (State state in states)
        {
            var nationProfile = NationProfileManager.GetNationProfile(state.StateOwnerID);
            for (int i = 0; i < state.Provinces.Length; i++)
            {
                var province = ProvinceDictionary.GetProvinceFromDictionary(state.Provinces[i]);
                province.SetOwner(state.StateOwnerID);
                nationProfile.AddProvinceToNation(province);
                province.ThisProvince.ProvinceStateID = state.StateID;
            }
            nationProfile.AddStateToNation(state);
        }
        onStatesInitialized?.Invoke();
    }
}
