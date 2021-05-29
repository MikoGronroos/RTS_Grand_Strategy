using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DivisionUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI amountOfDivisions;
    [SerializeField] private RawImage divisionIcon;
    [SerializeField] private RawImage divisionOwnerFlag;
    [SerializeField] private Image equipmentBar;
    [SerializeField] private Image organizationBar;

    private DivisionHolder _thisHolder;

    private void Awake()
    {
        _thisHolder = GetComponent<DivisionHolder>();
        _thisHolder.OnDivisionCreated += OnDivisionCreatedListener;
    }

    public void ChangeAmountOfDivisions(int amount)
    {
        amountOfDivisions.text = amount.ToString();
    }

    private void OnDisable()
    {
        _thisHolder.OnDivisionCreated -= OnDivisionCreatedListener;
    }

    private void OnDivisionCreatedListener(Division division, string ownerID)
    {
        ChangeDivisionOwnerFlag(NationProfileManager.GetNationProfile(ownerID).GetNation().CountryFlag);
    }

    public void ChangeDivisionIcon(Texture image)
    {
        divisionIcon.texture = image;
    }

    public void ChangeDivisionOwnerFlag(Texture image)
    {
        divisionOwnerFlag.texture = image;
    }

}
