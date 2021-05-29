[System.Serializable]
public class Stock
{

    public Stock(Equipment equipment, int amount)
    {
        StockEquipment = equipment;
        Amount = amount;
    }

    public Equipment StockEquipment;
    public int Amount;
}
