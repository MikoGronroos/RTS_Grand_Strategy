using UnityEngine;

public class PlayersManager : MonoBehaviour
{

    [SerializeField] private NationProfile localPlayerProfile;

    [SerializeField] private GameEvent gameEvent;

    #region Singleton

    private static PlayersManager _instance;

    public static PlayersManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        _instance = this;
    }

    public void ChangeLocalPlayerNation(NationProfile profile)
    {

        if (localPlayerProfile != null)
        {
            localPlayerProfile.LocalPlayer = false;
        }
        localPlayerProfile = profile;

        GameEventHub.LocalNationChanged.Profile = profile;
        gameEvent?.Invoke();

    }

    public string GetLocalPlayerNationID()
    {
        return localPlayerProfile.GetNation().CountryID;
    }

    public NationProfile GetLocalNationProfile()
    {
        return localPlayerProfile;
    }

    public bool GameHasLocalPlayer()
    {
        return localPlayerProfile != null;
    }

}
