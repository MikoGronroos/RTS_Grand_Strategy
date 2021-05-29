using UnityEngine;

public class TooltipManager : MonoBehaviour
{

    [SerializeField] private GameObject tooltipObject;

    public void EnableTooltip()
    {
        tooltipObject.SetActive(true);
    }

    public void SetPosition(Vector3 pos)
    {
        tooltipObject.transform.position = pos;
    }

    public void DisableTooltip()
    {
        tooltipObject.SetActive(false);
    }

}
