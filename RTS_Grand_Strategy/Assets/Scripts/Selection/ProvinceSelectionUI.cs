using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProvinceSelectionUI : MonoBehaviour
{

    [Header("State Info Panel")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private RawImage ownerFlag;
    [SerializeField] private RawImage foreignClaimsImage;
    [SerializeField] private Button closeInfoPanelButton;
    [SerializeField] private Button ownerCountryButton;
    [SerializeField] private Button foreignClaimsButton;

    [SerializeField] private TextMeshProUGUI manPowerAmountText;

    [Header("Country Politics Panel")]
    [SerializeField] private GameObject countryPoliticsPanel;
    [SerializeField] private Button closeCountryPoliticsPanel;

    [Header("Materials")]
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material outlineMat;

    private SpriteRenderer _currentSpriteRenderer;

    private void Awake()
    {
        closeInfoPanelButton.onClick.AddListener(CloseInfoPanel);
        ownerCountryButton.onClick.AddListener(OpenCountryPoliticsPanel);
        foreignClaimsButton.onClick.AddListener(OpenCountryPoliticsPanel);
        closeCountryPoliticsPanel.onClick.AddListener(CloseCountryPoliticsPanel);
    }

    private void Start()
    {
        CloseInfoPanel();
        CloseCountryPoliticsPanel();
    }

    public void OnProvinceChangedListener()
    {

        var profile = GameEventHub.ProvinceSelected.SelectedProfile;
        var claims = GameEventHub.ProvinceSelected.ForeignClaimsProfile;
        var selectedProvince = GameEventHub.ProvinceSelected.SelectedProvince;
        var renderer = GameEventHub.ProvinceSelected.Renderer;

        ownerFlag.texture = profile.GetNation().CountryFlag;
        foreignClaimsImage.texture = claims.GetNation().CountryFlag;
        manPowerAmountText.text = StatesDictionary.GetStateFromDictionary(selectedProvince.ProvinceStateID).Manpower.ToString();
        if (_currentSpriteRenderer != null)
        {
            _currentSpriteRenderer.material = defaultMat;
        }
        renderer.material = outlineMat;
        _currentSpriteRenderer = renderer;
        infoPanel.SetActive(true);
    }

    private void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }

    private void OpenCountryPoliticsPanel()
    {
        CloseInfoPanel();
        countryPoliticsPanel.SetActive(true);
    }

    private void CloseCountryPoliticsPanel()
    {
        countryPoliticsPanel.SetActive(false);
    }

}
