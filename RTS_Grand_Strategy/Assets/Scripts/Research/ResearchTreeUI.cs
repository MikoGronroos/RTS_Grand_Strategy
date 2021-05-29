using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchTreeUI : MonoBehaviour
{

    [SerializeField] private GameObject researchSlotPrefab;

    [SerializeField] private Transform researchParent; 

    [SerializeField] private Button infantryFolderButton;
    [SerializeField] private Button supportFolderButton;
    [SerializeField] private Button landDoctrineFolderButton;
    [SerializeField] private Button navalFolderButton;
    [SerializeField] private Button navalDoctrineFolderButton;
    [SerializeField] private Button airFolderButton;
    [SerializeField] private Button airDoctrineFolderButton;
    [SerializeField] private Button industryFolderButton;
    [SerializeField] private Button technologyFolderButton;

    [SerializeField] private List<Research> currentResearch = new List<Research>();

    private ResearchSystem _researchSystem;

    private List<GameObject> drawnResearchItems = new List<GameObject>();

    private void Awake()
    {
        _researchSystem = FindObjectOfType<ResearchSystem>();
        infantryFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Infantry);
            RedrawResearchTree();
        });
        supportFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Support);
            RedrawResearchTree();
        });
        landDoctrineFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.LandDoctrine);
            RedrawResearchTree();
        });
        navalFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Naval);
            RedrawResearchTree();
        });
        navalDoctrineFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.NavalDoctrine);
            RedrawResearchTree();
        });
        airFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Air);
            RedrawResearchTree();
        });
        airDoctrineFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.AirDoctrine);
            RedrawResearchTree();
        });
        technologyFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Technology);
            RedrawResearchTree();
        });
        industryFolderButton.onClick.AddListener(() => {
            currentResearch = GetFolderContent(ResearchFolder.Industry);
            RedrawResearchTree();
        });
    }

    public List<Research> GetFolderContent(ResearchFolder folder)
    {
        return _researchSystem.GetAllResearchFromFolder(folder);
    }

    public void RedrawResearchTree()
    {

        foreach (var item in drawnResearchItems)
        {
            Destroy(item);
        }

        drawnResearchItems.Clear();

        foreach (var slot in currentResearch)
        {
            GameObject newSlot = Instantiate(researchSlotPrefab, researchParent);
            newSlot.transform.localPosition = new Vector3(slot.Position.x, slot.Position.y, 0);
            newSlot.GetComponent<ResearchItem>().SetResearch(slot);
            drawnResearchItems.Add(newSlot);
        }
    }

}
