using System.Collections.Generic;
using UnityEngine;

public class DivisionMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    [SerializeField] private List<ProvinceHolder> route;
    [SerializeField] private ProvinceHolder currentHolder;

    [SerializeField] private int routeIndex = 0;

    [SerializeField] private float accuracy = 0.1f;

    private DivisionCombat _divisionCombat;
    private DivisionHolder _divisionHolder;

    public System.Action<ProvinceHolder> OnWaypointReached;
    public System.Action<ProvinceHolder> OnWaypointChanged;

    private void Awake()
    {
        _divisionCombat = GetComponent<DivisionCombat>();
        _divisionHolder = GetComponent<DivisionHolder>();
    }

    private void LateUpdate()
    {

        if (route.Count <= 0) return;

        if (currentHolder != null)
        {
            if (_divisionCombat.IsInCombat)
            {
                _divisionCombat.LeaveCombat(currentHolder);
            }
        }

        CheckNewProvince(route[routeIndex]);

        Vector3 lookAtGoal = new Vector3(route[routeIndex].GetMovementPoint().position.x, route[routeIndex].GetMovementPoint().position.y, 0);

        Vector3 direction = lookAtGoal - transform.position;

        if (direction.magnitude < accuracy)
        {
            if (currentHolder != null)
            {
                WaypointChanged(currentHolder);
            }
            WaypointReached(route[routeIndex]);
            routeIndex++;
            if (routeIndex >= route.Count)
            {
                route.Clear();
                routeIndex = 0;
            }
            else
            {
                CheckNewProvince(route[routeIndex]);
            }
        }
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void CheckNewProvince(ProvinceHolder holder)
    {
        if (CheckProvince.CheckForDivisions(holder))
        {
            if (CheckProvince.CheckForEnemyDivisions(holder, _divisionHolder.GetDivisionOwnerID()))
            {
                _divisionCombat.CombatCheck(holder);
                currentHolder = holder;
                return;
            }
            else
            {
                _divisionCombat.CombatCheck(holder);
            }
        }
    }

    private void WaypointReached(ProvinceHolder holder)
    {
        if (!CheckProvince.CheckIfDivisionOwnerIsOwnerOfTheProvince(holder, _divisionHolder.GetDivisionOwnerID())
            && NationProfileManager.GetNationProfile(holder.ThisProvince.ProvinceOwnerID).HasWarWithNationID(_divisionHolder.GetDivisionOwnerID()))
        {
            _divisionCombat.ConquerNewProvince(holder);
        }
        currentHolder = holder;
        OnWaypointReached?.Invoke(holder);
    }

    private void WaypointChanged(ProvinceHolder holder)
    {
        OnWaypointChanged?.Invoke(holder);
    }

    public void UpdateRoute(List<ProvinceHolder> route)
    {
        this.route = route;
    }

}
