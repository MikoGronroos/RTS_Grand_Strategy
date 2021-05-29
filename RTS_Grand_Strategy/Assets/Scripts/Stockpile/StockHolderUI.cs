using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StockHolderUI : MonoBehaviour
{

    [SerializeField] private RawImage icon;
    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentAmount;

    public void SetIcon(Texture texture)
    {
        icon.texture = texture;
    }

    public void SetEquipmentName(string name)
    {
        equipmentName.text = name;
    }

    public void SetEquipmentAmount(string amount)
    {
        equipmentAmount.text = amount;
    }

}
