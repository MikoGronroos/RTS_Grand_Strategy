using UnityEngine;
using UnityEngine.EventSystems;

public class ResearchSlot : ClickableUI
{

    public GameEvent OnResearchSlotClicked;

    private ResearchSlotUI _thisSlotUI;

    private void Awake()
    {
        _thisSlotUI = GetComponent<ResearchSlotUI>();
    }

    public override void OnUIClicked(PointerEventData eventData)
    {

        Debug.Log("Clicked Research Slot");
        GameEventHub.ResearchSlotClicked.ThisResearchSlot = this;
        OnResearchSlotClicked?.Invoke();

    }

    public void ChangeResearch(Research research)
    {
        _thisSlotUI.ChangeResearch(research);
    }

}
