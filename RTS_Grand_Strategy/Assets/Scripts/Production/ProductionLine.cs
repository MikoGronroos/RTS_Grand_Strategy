[System.Serializable]
public class ProductionLine
{

    public ProductionLine(Equipment equipment, float startProductionRate, float maxProductionRate)
    {
        FactoriesInUse = 1;
        EquipmentInProduction = equipment;
        CurrentProductionRate = startProductionRate;
        MaxProductionRate = maxProductionRate;
    }

    public int FactoriesInUse;
    public Equipment EquipmentInProduction;
    public float CurrentProductionRate;
    public float MaxProductionRate;

    public int Id;

    private NationStockpile _nationStockpile;

    public void SetNationStockpile(NationStockpile stockpile)
    {
        _nationStockpile = stockpile;
    }

    public void CreateNewEquipment()
    {
        _nationStockpile.AddToStockpile(EquipmentInProduction, 1 * FactoriesInUse);
    }

}
