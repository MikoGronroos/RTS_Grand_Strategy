using System.Collections.Generic;
using UnityEngine;

public class NationStockpile : MonoBehaviour
{

    [SerializeField] private List<Stock> stockpile = new List<Stock>();

    [SerializeField] private GameEvent onStockpileCreated;
    [SerializeField] private GameEvent onAddedToStockpile;

    private NationProfile _profile;

    private void Awake()
    {
        _profile = GetComponent<NationProfile>();
    }

    public void AddToStockpile(Equipment equipment, int amount)
    {
        if (StockpileHasEquipment(equipment))
        {

            var stock = GetStockpileWithEquipment(equipment);
            stock.Amount += amount;

            if (_profile.LocalPlayer)
            {

                GameEventHub.AddedToStockpile.ThisStock = stock;
                onAddedToStockpile?.Invoke();

            }

        }
        else
        {
            Stock stock = new Stock(equipment, amount);
            stockpile.Add(stock);

            if (_profile.LocalPlayer)
            {

                GameEventHub.StockpileCreated.ThisStock = stock;
                onStockpileCreated?.Invoke();

            }

        }
    }

    public Stock GetStockpileWithEquipment(Equipment equipment)
    {
        for (int i = 0; i < stockpile.Count; i++)
        {
            if (stockpile[i].StockEquipment == equipment)
            {
                return stockpile[i];
            }
        }
        return null;
    }

    public bool StockpileHasEquipment(Equipment equipment)
    {
        for (int i = 0; i < stockpile.Count; i++)
        {
            if (stockpile[i].StockEquipment == equipment)
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerable<Stock> GetStockpile()
    {
        return stockpile;
    }

}
