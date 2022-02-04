using UnityEngine;

public class ProvinceTooltip : MonoBehaviour
{

    private ProvinceHolder _provinceHolder;
    private PlayersManager _playersManager;

    private void Awake()
    {
        _provinceHolder = GetComponent<ProvinceHolder>();
        _playersManager = FindObjectOfType<PlayersManager>();
    }

    private void OnMouseEnter()
    {
        if (!_playersManager.GetLocalNationProfile().GetNationsDivisions().IfProvinceIsAllowed(_provinceHolder.ThisProvince.ProvinceOwnerID))
        {
            CursorManager.ChangeCursor("NotAllowedCursor");
        }
    }

    private void OnMouseExit()
    {
        CursorManager.ChangeCursor("DefaultCursor");
    }

}
