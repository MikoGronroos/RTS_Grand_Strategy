using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoliticsSystemUI : MonoBehaviour
{

    [SerializeField] private GameObject diplomacyPanel;
    [SerializeField] private GameObject detailsPanel;

    [SerializeField] private GameObject agreementVerificationPanel;

    [Header("Buttons")]

    [SerializeField] private Button openDiplomacyPanelButton;
    [SerializeField] private Button openDetailsPanelButton;

    [SerializeField] private Button[] agreementButtons;

    [SerializeField] private Button closeVerificationPanelButton;
    [SerializeField] private Button acceptVerificationButton;

    [Header("Politics Available Marks")]

    [SerializeField] private TextMeshProUGUI[] marks;

    [Header("Colors")]

    [SerializeField] private Color availableColor;
    [SerializeField] private Color notAvailableColor;

    [Header("Events")]

    [SerializeField] private GameEvent onAcceptedAgreement;

    private int _amountOfAgreements;

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

    private void DrawPoliticAgreements()
    {

        var profile = GameEventHub.ProvinceSelected.SelectedProfile;
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
            AcceptVerification(id);
            DrawPoliticAgreements();
            acceptVerificationButton.onClick.RemoveAllListeners();
        });
    }

    private void CloseAgreementVerificationPanel()
    {
        agreementVerificationPanel.SetActive(false);
        acceptVerificationButton.onClick.RemoveAllListeners();
    }

    private void AcceptVerification(int type)
    {

        GameEventHub.AcceptedAgreement.Id = type;

        onAcceptedAgreement?.Invoke();

        agreementVerificationPanel.SetActive(false);
    }

}
