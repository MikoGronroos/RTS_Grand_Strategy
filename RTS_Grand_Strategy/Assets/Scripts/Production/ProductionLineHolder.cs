using System;
using UnityEngine;
using UnityEngine.UI;

public class ProductionLineHolder : MonoBehaviour
{

    [SerializeField] private RawImage EquipmentIcon;

    [SerializeField] private ProductionLine productionLine;

    [SerializeField] private int maxAmountOfFactories = 150;

    public Action<int> Callback;

    public Action<int> OnProdLineDeleted;

    public void SetEquipmentIcon(Texture texture)
    {
        EquipmentIcon.texture = texture;
    }

    public void SubscribeToEvent(Action<int> method)
    {
        OnProdLineDeleted += method;
    }

    public void RemoveFactory()
    {
        if (productionLine.FactoriesInUse <= 0)
        {
            return;
        }
        productionLine.FactoriesInUse--;
        Callback?.Invoke(productionLine.FactoriesInUse);
    }

    public void AddFactory()
    {
        if (productionLine.FactoriesInUse >= maxAmountOfFactories)
        {
            return;
        }
        productionLine.FactoriesInUse++;
        Callback?.Invoke(productionLine.FactoriesInUse);
    }

    public void DeleteProductionLine()
    {
        OnProdLineDeleted?.Invoke(productionLine.Id);
        Destroy(gameObject);
    }

    public void SetProductionLine(ProductionLine line)
    {
        productionLine = line;
    }

}
