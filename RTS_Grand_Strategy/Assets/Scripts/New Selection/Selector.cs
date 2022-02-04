using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    [SerializeField] private Transform selectionAreaTransform;

    [SerializeField] private List<DivisionHolder> selectedDivisions;

    private Vector3 startPosition;

    private PlayersManager _playersManager;

    private void Awake()
    {
        selectedDivisions = new List<DivisionHolder>();
        _playersManager = FindObjectOfType<PlayersManager>();
        selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = MikoUtils.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = MikoUtils.GetMouseWorldPosition();

            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );

            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0))
        {

            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] colliders =  Physics2D.OverlapAreaAll(startPosition, MikoUtils.GetMouseWorldPosition());

            if (!Input.GetKey(KeyCode.LeftShift))
            {
                selectedDivisions.Clear();
            }

            foreach (Collider2D collider in colliders)
            {
                DivisionHolder holder = collider.GetComponent<DivisionHolder>();

                if (holder != null)
                {

                    if (_playersManager.GetLocalPlayerNationID() == holder.GetDivisionOwnerID())
                    {
                        if (!selectedDivisions.Contains(holder))
                        {
                            selectedDivisions.Add(holder);
                        }
                    }
                }
            }
        }
    }

    public bool DivisionIsSelected()
    {
        return selectedDivisions.Count > 0;
    }

    public IEnumerable<DivisionHolder> GetCurrentlySelectedDivisions()
    {
        return selectedDivisions;
    }

}
