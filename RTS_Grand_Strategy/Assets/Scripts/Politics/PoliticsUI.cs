using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PoliticsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI politicalPowerText;
    [SerializeField] private RawImage localPlayerNationFlag;
    [SerializeField] private TextMeshProUGUI warSupportText;
    [SerializeField] private TextMeshProUGUI stabilityText;

    [Header("Panels")]
    [SerializeField] private GameObject[] panels;

    [Header("Buttons")]
    [SerializeField] private Button productionButton;
    [SerializeField] private Button researchButton;
    [SerializeField] private Button logisticsButton;
    [SerializeField] private Button industyButton;
    [SerializeField] private Button decisionButton;
    [SerializeField] private Button recruitButton;
    [SerializeField] private Button exitProductionButton;
    [SerializeField] private Button exitResearchButton;
    [SerializeField] private Button exitLogisticsButton;
    [SerializeField] private Button exitIndustryButton;
    [SerializeField] private Button exitDecisionButton;
    [SerializeField] private Button exitRecruitButton;

    private int _currentlyOpenPanelIndex = 0;

    private NationProfile currentNationProfile;

    private void Awake()
    {
        exitProductionButton.onClick.AddListener(CloseAllPanels);
        exitResearchButton.onClick.AddListener(CloseAllPanels);
        exitLogisticsButton.onClick.AddListener(CloseAllPanels);
        exitIndustryButton.onClick.AddListener(CloseAllPanels);
        exitDecisionButton.onClick.AddListener(CloseAllPanels);
        exitRecruitButton.onClick.AddListener(CloseAllPanels);

        productionButton.onClick.AddListener(()=> {
            OpenPanelWithIndex(1);
        });

        researchButton.onClick.AddListener(() => {
            OpenPanelWithIndex(2);
        });

        logisticsButton.onClick.AddListener(() => {
            OpenPanelWithIndex(3);
        });

        industyButton.onClick.AddListener(() => {
            OpenPanelWithIndex(4);
        });

        decisionButton.onClick.AddListener(() => {
            OpenPanelWithIndex(5);
        });

        recruitButton.onClick.AddListener(() => {
            OpenPanelWithIndex(6);
        });

    }

    private void ChangeNationInfo(float politicalPower, float stability, float warSupport)
    {
        politicalPowerText.text = Mathf.FloorToInt(politicalPower).ToString();
        stabilityText.text = Mathf.FloorToInt(stability).ToString();
        warSupportText.text = Mathf.FloorToInt(warSupport).ToString();
    }

    public void OnPoliticalPowerChangedListener()
    {
        float value = GameEventHub.PoliticalPowerChanged.value;
        politicalPowerText.text = Mathf.FloorToInt(value).ToString();
    }

    public void OnStabilityChangedListener()
    {
        float value = GameEventHub.StabilityChanged.value;
        stabilityText.text = Mathf.FloorToInt(value).ToString();
    }

    public void OnWarSupportChangedListener()
    {
        float value = GameEventHub.WarSupportChanged.value;
        warSupportText.text = Mathf.FloorToInt(value).ToString();
    }

    public void OnLocalPlayerNationChangedListener()
    {
        NationProfile nationProfile = GameEventHub.LocalNationChanged.Profile;
        currentNationProfile = nationProfile;
        if (currentNationProfile != null)
        {
            ChangeNationInfo(nationProfile.GetPoliticalSystem().GetPoliticalPower(), nationProfile.GetNation().Stability, nationProfile.GetNation().WarSupport);
            localPlayerNationFlag.texture = nationProfile.GetNation().CountryFlag;
        }
        else
        {
            localPlayerNationFlag.texture = null;
            ChangeNationInfo(0, 0, 0);
        }
    }

    private void OpenPanelWithIndex(int index)
    {

        if (_currentlyOpenPanelIndex == index)
        {
            panels[index - 1].SetActive(false);
            _currentlyOpenPanelIndex = 0;
            return;
        }

        if (_currentlyOpenPanelIndex > 0)
        {
            panels[_currentlyOpenPanelIndex - 1].SetActive(false);
        }

        panels[index - 1].SetActive(true);

        _currentlyOpenPanelIndex = index;
    }

    private void CloseAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }
}
