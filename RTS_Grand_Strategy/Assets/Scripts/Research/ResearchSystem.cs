using System.Collections.Generic;
using UnityEngine;

public class ResearchSystem : MonoBehaviour
{

    #region Singleton

    private static ResearchSystem _instance;

    public static ResearchSystem Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion

    [SerializeField] private string path;

    [SerializeField] private GameEvent onResearchLoaded;

    [SerializeField] private List<Research> allResearch = new List<Research>();

    [SerializeField] private List<Research> infantryResearch = new List<Research>();
    [SerializeField] private List<Research> supportResearch = new List<Research>();
    [SerializeField] private List<Research> landDoctrineResearch = new List<Research>();
    [SerializeField] private List<Research> airResearch = new List<Research>();
    [SerializeField] private List<Research> airDoctrineResearch = new List<Research>();
    [SerializeField] private List<Research> navalResearch = new List<Research>();
    [SerializeField] private List<Research> navalDoctrineResearch = new List<Research>();
    [SerializeField] private List<Research> technologyResearch = new List<Research>();
    [SerializeField] private List<Research> industryResearch = new List<Research>();

    private void Awake()
    {
        _instance = this;
    }

    private void Start() 
    {

        foreach (Research research in Resources.LoadAll<Research>(path))
        {
            allResearch.Add(research);
            switch (research.Folder)
            {
                case ResearchFolder.Infantry:
                    infantryResearch.Add(research);
                    break;
                case ResearchFolder.Support:
                    supportResearch.Add(research);
                    break;
                case ResearchFolder.LandDoctrine:
                    landDoctrineResearch.Add(research);
                    break;
                case ResearchFolder.Air:
                    airResearch.Add(research);
                    break;
                case ResearchFolder.AirDoctrine:
                    airDoctrineResearch.Add(research);
                    break;
                case ResearchFolder.Naval:
                    navalResearch.Add(research);
                    break;
                case ResearchFolder.NavalDoctrine:
                    navalDoctrineResearch.Add(research);
                    break;
                case ResearchFolder.Technology:
                    technologyResearch.Add(research);
                    break;
                case ResearchFolder.Industry:
                    industryResearch.Add(research);
                    break;
            }
        }
        onResearchLoaded?.Invoke();
    }


    public List<Research> GetAllResearchFromFolder(ResearchFolder folder)
    {
        switch (folder)
        {
            case ResearchFolder.Infantry:
                return infantryResearch;
            case ResearchFolder.Support:
                return supportResearch;
            case ResearchFolder.LandDoctrine:
                return landDoctrineResearch;
            case ResearchFolder.Air:
                return airResearch;
            case ResearchFolder.AirDoctrine:
                return airDoctrineResearch;
            case ResearchFolder.Naval:
                return navalResearch;
            case ResearchFolder.NavalDoctrine:
                return navalDoctrineResearch;
            case ResearchFolder.Technology:
                return technologyResearch;
            case ResearchFolder.Industry:
                return industryResearch;
        }
        return null;
    }

    public Research GetResearchFromAllResearch(string name)
    {
        foreach (var research in allResearch)
        {
            if (research.ResearchName.Equals(name))
            {
                return research;
            }
        }
        return null;
    }

}
