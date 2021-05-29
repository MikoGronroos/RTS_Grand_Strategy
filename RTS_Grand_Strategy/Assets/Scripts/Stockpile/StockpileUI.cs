using System.Collections.Generic;
using UnityEngine;

public class StockpileUI : MonoBehaviour
{

    [SerializeField] private List<StockHolder> stockHolders = new List<StockHolder>();

    [SerializeField] private GameObject stockObjectPrefab;
    [SerializeField] private Transform stockObjectParent;

    public void LocalNationChangedListener()
    {
        ClearStockUI();
        RedrawStockpile();
    }

    private void RedrawStockpile()
    {
        var stockpile = GameEventHub.LocalNationChanged.Profile.GetNationStockpile().GetStockpile();
        foreach (var stock in stockpile)
        {
            CreateNewStockObject(stock);
        }
    }

    public void ClearStockUI()
    {
        foreach (var stock in stockHolders)
        {
            Destroy(stock.gameObject);
        }
        stockHolders.Clear();
    }

    public void OnStockpileCreated()
    {
        var stock = GameEventHub.StockpileCreated.ThisStock;
        CreateNewStockObject(stock);
    }

    public void AlterStockpile()
    {
        var stock = GameEventHub.AddedToStockpile.ThisStock;

        foreach (var holder in stockHolders)
        {
            if (holder.GetEquipment().Equals(stock.StockEquipment))
            {
                holder.GetHolderUI().SetEquipmentAmount(stock.Amount.ToString());
            }
        }
    }

    private void CreateNewStockObject(Stock stock)
    {
        GameObject stockObject = Instantiate(stockObjectPrefab, stockObjectParent);
        var holder = stockObject.GetComponent<StockHolder>();
        holder.AddEquipment(stock.StockEquipment);
        holder.GetHolderUI().SetEquipmentAmount(stock.Amount.ToString());
        holder.GetHolderUI().SetEquipmentName(stock.StockEquipment.Name);
        holder.GetHolderUI().SetIcon(stock.StockEquipment.Icon.texture);
        stockHolders.Add(holder);
    }

}
