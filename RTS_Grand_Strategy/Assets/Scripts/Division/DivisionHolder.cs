using UnityEngine;

public class DivisionHolder : MonoBehaviour
{

    [SerializeField] private Division thisDivision;
    [SerializeField] private string divisionOwnerID;

    private DivisionMovement _thisDivisionMovement;

    public System.Action<Division, string> OnDivisionCreated;

    private void Awake()
    {
        _thisDivisionMovement = GetComponent<DivisionMovement>();
    }

    private void Start()
    {
        DivisionHasBeenCreated();
    }

    private void OnEnable()
    {
        _thisDivisionMovement.OnWaypointChanged += OnWaypointChangedListener;
        _thisDivisionMovement.OnWaypointReached += OnWaypointReachedListener;
    }


    private void OnDisable()
    {
        _thisDivisionMovement.OnWaypointChanged -= OnWaypointChangedListener;
        _thisDivisionMovement.OnWaypointReached -= OnWaypointReachedListener;
    }

    public Division GetDivision()
    {
        return thisDivision;
    }

    public DivisionMovement GetDivisionMovement()
    {
        return _thisDivisionMovement;
    }

    public string GetDivisionOwnerID()
    {
        return divisionOwnerID;
    }

    private void OnWaypointReachedListener(ProvinceHolder holder)
    {
        holder.GetProvinceDivisions().AddDivisionToList(this);
    }

    private void OnWaypointChangedListener(ProvinceHolder holder)
    {
        holder.GetProvinceDivisions().RemoveDivisionFromList(this);
    }

    private void DivisionHasBeenCreated()
    {
        OnDivisionCreated?.Invoke(thisDivision, divisionOwnerID);
        NationProfileManager.GetNationProfile(divisionOwnerID).GetNationsDivisions().AddToNationsDivisionsList(this);
    }

}
