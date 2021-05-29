using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchUI : MonoBehaviour
{

    [SerializeField] private List<GameObject> currentSlots = new List<GameObject>();


    [SerializeField] private GameObject researchSlotPrefab;

    [SerializeField] private Transform researchSlotParent;

    [SerializeField] private GameObject researchTree;

    [SerializeField] private Button closeResearchTree;

    private void Awake()
    {
        closeResearchTree.onClick.AddListener(ToggleResearchPanel);
    }

    public void RefreshResearchSlots()
    {
        var research = GameEventHub.LocalNationChanged.Profile.GetNationResearch();

        foreach (var slot in currentSlots)
        {
            Destroy(slot);
        }

        for (int i = 0; i < research.GetAmountOfResearchSlots(); i++)
        {
            GameObject newSlot = Instantiate(researchSlotPrefab, researchSlotParent);
        }
    }

    public void ToggleResearchPanel()
    {
        researchTree.SetActive(!researchTree.activeSelf);
    }

}
