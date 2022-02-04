using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NationDetailsUI : MonoBehaviour
{

    [Header("Panels")]

    [SerializeField] private GameObject nationDetailsPanel;

    [SerializeField] private GameObject diplomacyPanel;
    [SerializeField] private GameObject detailsPanel;

    [SerializeField] private GameObject agreementVerificationPanel;

    [Header("Buttons")]

    [SerializeField] private Button openDiplomacyPanelButton;
    [SerializeField] private Button openDetailsPanelButton;

    [SerializeField] private Button[] agreementButtons;

    [SerializeField] private Button closeVerificationPanelButton;
    [SerializeField] private Button acceptVerificationButton;

    [SerializeField] private Button closeNationDetailsPanel;

    [Header("Politics Available Marks")]

    [SerializeField] private TextMeshProUGUI[] marks;

    [Header("Colors")]

    [SerializeField] private Color availableColor;
    [SerializeField] private Color notAvailableColor;

    private int _amountOfAgreements;

    private NationDetails _nationDetails;

    private void Awake()
    {
        _nationDetails = GetComponent<NationDetails>();

        closeNationDetailsPanel.onClick.AddListener(() => {
            ToggleNationDetailsPanel(false);
        });

    }

    public void OnPoliticsSystemActivated()
    {

        _amountOfAgreements = GameEventHub.PoliticsSystemActivated.AmountOfAgreements;

        openDiplomacyPanelButton.onClick.AddListener(OpenDiplomacyPanel);

        openDetailsPanelButton.onClick.AddListener(OpenDetailsPanel);

        //Agreement Buttons
        for (int i = 0; i < agreementButtons.Length; i++)
        {
            int index = i;
            agreementButtons[index].onClick.AddListener(() => {
                OpenAgreementVerificationPanel(index + 1);
            });
        }

        closeVerificationPanelButton.onClick.AddListener(CloseAgreementVerificationPanel);

    }

    public void OnSelectedNationChanged()
    {

        DrawPoliticAgreements();

    }

    public void NationDetailToggleListener()
    {

        bool value = GameEventHub.OnNationDetailToggle.ToggleValue;

        DrawPoliticAgreements();

        ToggleNationDetailsPanel(value);

    }

    private void ToggleNationDetailsPanel(bool value)
    {
        nationDetailsPanel.SetActive(value);
    }

    private void DrawPoliticAgreements()
    {

        var profile = NationProfileManager.GetNationProfile(GameEventHub.OnNationDetailToggle.NationId);
        var localProfile = GameEventHub.LocalNationChanged.Profile;

        for (int i = 0; i < _amountOfAgreements; i++)
        {
            if (profile.CheckIfHasAgreement(localProfile.GetNation().CountryID, i + 1))
            {
                marks[i].color = notAvailableColor;
            }
            else
            {
                marks[i].color = availableColor;
            }
        }
    }

    private void OpenDetailsPanel()
    {
        detailsPanel.SetActive(true);
        diplomacyPanel.SetActive(false);
    }

    private void OpenDiplomacyPanel()
    {
        diplomacyPanel.SetActive(true);
        detailsPanel.SetActive(false);
    }

    private void OpenAgreementVerificationPanel(int id)
    {
        agreementVerificationPanel.SetActive(true);
        acceptVerificationButton.onClick.AddListener(() => {
            _nationDetails.AcceptVerification(id);
            CloseAgreementVerificationPanel();
            DrawPoliticAgreements();
        });
    }

    private void CloseAgreementVerificationPanel()
    {
        agreementVerificationPanel.SetActive(false);
        acceptVerificationButton.onClick.RemoveAllListeners();
    }

}
