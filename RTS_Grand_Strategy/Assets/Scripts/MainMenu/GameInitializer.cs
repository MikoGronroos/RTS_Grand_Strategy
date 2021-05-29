using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public string ID;

    private bool _nationSet = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetLocalPlayerNation()
    {
        if (!_nationSet)
        {
            NationProfileManager.GetNationProfile(ID).LocalPlayer = true;
            _nationSet = true;
        }
    }

}
