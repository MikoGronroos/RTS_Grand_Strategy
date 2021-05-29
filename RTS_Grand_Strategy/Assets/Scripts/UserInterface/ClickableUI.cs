using UnityEngine.EventSystems;
using UnityEngine;

public class ClickableUI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        OnUIClicked(eventData);
    }

    public virtual void OnUIClicked(PointerEventData eventData)
    {

    }

}
