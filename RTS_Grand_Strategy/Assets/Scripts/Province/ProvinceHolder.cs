using UnityEngine;

public class ProvinceHolder : MonoBehaviour, ISelectable
{

    [SerializeField] private Transform provinceMovementPoint;

    [SerializeField] private Province thisProvince;

    private ProvinceDivisions _provinceDivisions;
    private ProvinceSelection _provinceSelection;
    private ProvinceCombat _provinceCombat;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Vector2 _movementPosition;

    public Province ThisProvince
    {
        get { return thisProvince; }
        set
        {
            thisProvince = value;
        }
    }

    private void Awake()
    {
        _provinceCombat = GetComponent<ProvinceCombat>();
        _provinceDivisions = GetComponent<ProvinceDivisions>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _provinceSelection = FindObjectOfType<ProvinceSelection>();
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag.Equals("ProvinceMovementPoint"))
            {
                provinceMovementPoint = transform.GetChild(i);
                break;
            }
        }
        provinceMovementPoint.transform.localPosition = new Vector3(_movementPosition.x, _movementPosition.y, 1);
    }

    private void LoadColor()
    {
        SetColor(NationProfileManager.GetNationProfile(ThisProvince.ProvinceOwnerID).GetNation().GetCountryColor());
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public Transform GetMovementPoint()
    {
        return provinceMovementPoint;
    }

    public void SetMovementPointPos(Vector2 pos)
    {
        _movementPosition = pos;
    }

    public void SetOwner(string id)
    {
        ThisProvince.ProvinceOwnerID = id;
        LoadColor();
    }

    public SpriteRenderer GetProvinceSpriteRenderer()
    {
        return _spriteRenderer;
    }

    public ProvinceDivisions GetProvinceDivisions()
    {
        return _provinceDivisions;
    }

    public ProvinceCombat GetProvinceCombat()
    {
        return _provinceCombat;
    }

    public void Select()
    {
        _provinceSelection.SetSelectedArea(thisProvince, GetComponent<SpriteRenderer>());
    }
}
