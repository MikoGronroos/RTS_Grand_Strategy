using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ProvinceSelectionUI : MonoBehaviour
{

    [Header("Province Info Panel")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private RawImage ownerFlag;
    [SerializeField] private Button closeInfoPanelButton;
    [SerializeField] private Button ownerCountryButton;
    [SerializeField] private Transform foreignClaimButtonsParent;
    [SerializeField] private GameObject foreignClaimButtonPrefab;

    [SerializeField] private TextMeshProUGUI manPowerAmountText;

    [Header("Materials")]
    [SerializeField] private Material defaultMat;
    [SerializeField] private Material outlineMat;

    [Header("Events")]
    [SerializeField] private GameEvent nationDetailPanelToggleEvent;

    private SpriteRenderer _currentSpriteRenderer;

    private List<GameObject> _foreignClaimButtons = new List<GameObject>();

    private void Awake()
    {
        closeInfoPanelButton.onClick.AddListener(CloseInfoPanel);
    }

    private void Start()
    {
        CloseInfoPanel();
    }

    public void OnProvinceChangedListener()
    {

        var profile = GameEventHub.ProvinceSelected.SelectedProfile;
        var claims = GameEventHub.ProvinceSelected.ForeignClaimProfileIds;
        var selectedProvince = GameEventHub.ProvinceSelected.SelectedProvince;
        var renderer = GameEventHub.ProvinceSelected.Renderer;

        if (_foreignClaimButtons.Count > 0)
        {
            foreach (var button in _foreignClaimButtons)
            {
                Destroy(button);
            }
            _foreignClaimButtons.Clear();
        }

        foreach (var claim in claims)
        {
            GameObject button = Instantiate(foreignClaimButtonPrefab, foreignClaimButtonsParent);
            button.GetComponent<RawImage>().texture = NationProfileManager.GetNationProfile(claim).GetNation().CountryFlag;
            button.GetComponent<Button>().onClick.AddListener(() => {
                TriggerToggleNationDetailEvent(claim, true);
            });
            _foreignClaimButtons.Add(button);
        }

        ownerFlag.texture = profile.GetNation().CountryFlag;
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

    private void TriggerToggleNationDetailEvent(string id, bool value)
    {

        GameEventHub.OnNationDetailToggle.NationId = id;
        GameEventHub.OnNationDetailToggle.ToggleValue = value;

        nationDetailPanelToggleEvent?.Invoke();
    }

}
