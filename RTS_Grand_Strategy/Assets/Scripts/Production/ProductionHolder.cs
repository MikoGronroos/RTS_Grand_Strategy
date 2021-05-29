using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductionHolder : ClickableUI
{

    private RawImage _holderIcon;

    private PlayersManager _playersManager;

    public Texture HolderIcon {
        set
        {
            if (_holderIcon == null)
            {
                _holderIcon = GetComponent<RawImage>();
                _holderIcon.texture = value;
            }
        }
    }

    public Equipment CurrentEquipment;

    private void Awake()
    {
        _playersManager = FindObjectOfType<PlayersManager>();
    }

    public override void OnUIClicked(PointerEventData eventData)
    {

        _playersManager.GetNationProfile().GetNationProduction().CreateNewProductionLine(CurrentEquipment);

    }
}
