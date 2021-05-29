using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionUI : MonoBehaviour
{

    [SerializeField] private Button airProduction; // tab number = 1
    [SerializeField] private Button infantryProduction; // tab number = 2
    [SerializeField] private Button navalProduction; // tab number = 3
    [SerializeField] private Button armoredProduction; // tab number = 4

    [SerializeField] private GameObject availableEquipmentPanel;
    [SerializeField] private GameObject availableEquipmentPrefab;

    [SerializeField] private List<GameObject> currentEquipmentPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> currentProductionLinePrefabs = new List<GameObject>();

    [SerializeField] private Transform availableEquipmentParent;

    [SerializeField] private GameObject productionLinePrefab;
    [SerializeField] private Transform productionLineParent;

    [SerializeField] private bool availableEquipmentIsOpen = false;

    private NationProfile currentProfile;

    private void Awake()
    {
        airProduction.onClick.AddListener(() => {
            ToggleAvailableEquipmentPanel(1);
        });
        infantryProduction.onClick.AddListener(() => {
            ToggleAvailableEquipmentPanel(2);
        });
        navalProduction.onClick.AddListener(() => {
            ToggleAvailableEquipmentPanel(3);
        });
        armoredProduction.onClick.AddListener(() => {
            ToggleAvailableEquipmentPanel(4);
        });
    }

    private void ToggleAvailableEquipmentPanel(int number)
    {

        foreach (var item in currentProfile.GetNationProduction().GetAvailableEquipmentWithIndex(number))
        {
            GameObject availableEquipmentObject = Instantiate(availableEquipmentPrefab, availableEquipmentParent);
            var holder = availableEquipmentObject.GetComponent<ProductionHolder>();
            holder.HolderIcon = item.Icon.texture;
            holder.CurrentEquipment = item;
            currentEquipmentPrefabs.Add(availableEquipmentObject);
        }

        if (availableEquipmentIsOpen)
        {
            foreach (var prefab in currentEquipmentPrefabs)
            {
                Destroy(prefab);
            }
            currentEquipmentPrefabs.Clear();
        }


        availableEquipmentIsOpen = !availableEquipmentIsOpen;
        availableEquipmentPanel.SetActive(!availableEquipmentPanel.activeSelf);
    }

    public void ProductionLineCreated(ProductionLine prodLine, System.Action<int> method)
    {
        GameObject productionLine = Instantiate(productionLinePrefab, productionLineParent);
        currentProductionLinePrefabs.Add(productionLine);
        var holder = productionLine.GetComponent<ProductionLineHolder>();
        holder.SetProductionLine(prodLine);
        holder.SubscribeToEvent(method);
        holder.SetEquipmentIcon(prodLine.EquipmentInProduction.Icon.texture);
    }

    private void ClearProductionLines()
    {
        foreach (var productionLine in currentProductionLinePrefabs)
        {
            Destroy(productionLine);
        }
        currentProductionLinePrefabs.Clear();
    }

    private void RedrawProductionLines()
    {
        foreach (var productionLine in currentProfile.GetNationProduction().GetProductionLines())
        {
            ProductionLineCreated(productionLine, currentProfile.GetNationProduction().RemoveFromProductionListWithId);
        }
    }

    public void OnLocalNationChangedListener()
    {
        currentProfile = GameEventHub.LocalNationChanged.Profile;
        ClearProductionLines();
        RedrawProductionLines();
    }
}
