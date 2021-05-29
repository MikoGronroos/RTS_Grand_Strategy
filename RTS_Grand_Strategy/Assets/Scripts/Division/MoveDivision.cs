using System.Collections.Generic;
using UnityEngine;

public class MoveDivision : MonoBehaviour
{

    [SerializeField] private LayerMask _valiableMask;

    private Selector _divisionSelection;
    private Camera _camera;
    private PlayersManager _playersManager;

    private void Awake()
    {
        _divisionSelection = FindObjectOfType<Selector>();
        _playersManager = FindObjectOfType<PlayersManager>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _divisionSelection.DivisionIsSelected())
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _valiableMask);
            if (hit.transform != null)
            {
                if (hit.transform.TryGetComponent(out ProvinceHolder holder))
                {
                    if (_playersManager.GetNationProfile().GetNationsDivisions().IfProvinceIsAllowed(holder))
                    {
                        List<ProvinceHolder> route = new List<ProvinceHolder>();
                        route.Add(holder);
                        foreach (var divison in _divisionSelection.GetCurrentlySelectedDivisions())
                        {
                            divison.GetDivisionMovement().UpdateRoute(route);
                        }
                    }
                }
            }
        }
    }
}
