using System.Collections.Generic;
using UnityEngine;

public class NationProduction : MonoBehaviour
{

    [SerializeField] private List<Equipment> availableInfantryEquipment = new List<Equipment>();
    [SerializeField] private List<Equipment> availableArmoredEquipment = new List<Equipment>();
    [SerializeField] private List<Equipment> availableAirEquipment = new List<Equipment>();
    [SerializeField] private List<Equipment> availableNavalEquipment = new List<Equipment>();

    [SerializeField] private List<ProductionLine> nationProductionLines = new List<ProductionLine>();

    private NationStockpile _nationStockpile;

    private ProductionUI _productionUI;

    private void Awake()
    {
        _nationStockpile = GetComponent<NationStockpile>();
        _productionUI = FindObjectOfType<ProductionUI>();
        foreach (var productionLine in nationProductionLines)
        {
            InitStockpile(productionLine);
        }
    }

    private void InitStockpile(ProductionLine productionLine)
    {
        TimeSystem.OnDayChanged += productionLine.CreateNewEquipment;
        productionLine.Id = Random.Range(0, 9999999);
        _productionUI.ProductionLineCreated(productionLine, RemoveFromProductionListWithId);
        productionLine.SetNationStockpile(_nationStockpile);
    }


    public void CreateNewProductionLine(Equipment equipment)
    {
        ProductionLine newLine = new ProductionLine(equipment, 0.10f, 1f);
        InitStockpile(newLine);
        nationProductionLines.Add(newLine);
    }

    public void AddNewAvailableEquipment(Equipment equipment)
    {
        switch (equipment.Type)
        {
            case EquipmentType.Infantry:
                availableInfantryEquipment.Add(equipment);
                break;
            case EquipmentType.Armored:
                availableArmoredEquipment.Add(equipment);
                break;
            case EquipmentType.Air:
                availableAirEquipment.Add(equipment);
                break;
            case EquipmentType.Naval:
                availableNavalEquipment.Add(equipment);
                break;
        }
    }

    public void RemoveFromProductionListWithId(int id)
    {
        for (int i = 0; i < nationProductionLines.Count; i++)
        {
            if (nationProductionLines[i].Id == id)
            {
                TimeSystem.OnDayChanged -= nationProductionLines[i].CreateNewEquipment;
                nationProductionLines.Remove(nationProductionLines[i]);
            }
        }
    }

    public List<Equipment> GetAvailableEquipmentWithIndex(int index)
    {
        switch (index)
        {
            case 1:
                return availableAirEquipment;
            case 2:
                return availableInfantryEquipment;
            case 3:
                return availableNavalEquipment;
            case 4:
                return availableArmoredEquipment;
        }
        return null;
    }

    public IEnumerable<ProductionLine> GetProductionLines()
    {
        return nationProductionLines;
    }

}
