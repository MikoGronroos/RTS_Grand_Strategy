using UnityEngine;

[RequireComponent(typeof(StockHolderUI))]
public class StockHolder : MonoBehaviour
{

    [SerializeField] private StockHolderUI holderUI;

    private Equipment _equipment;

    public void AddEquipment(Equipment equipment)
    {
        _equipment = equipment;
    }

    public StockHolderUI GetHolderUI()
    {
        return holderUI;
    }

    public Equipment GetEquipment()
    {
        return _equipment;
    }

}
