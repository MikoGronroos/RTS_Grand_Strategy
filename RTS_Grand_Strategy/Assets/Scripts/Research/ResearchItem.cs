using UnityEngine.EventSystems;
using UnityEngine;

public class ResearchItem : ClickableUI
{

    [SerializeField] private Research thisResearch;

    public override void OnUIClicked(PointerEventData eventData)
    {

        GameEventHub.ResearchSlotClicked.ThisResearchSlot.ChangeResearch(thisResearch);
        PlayersManager.Instance.GetNationProfile().GetNationResearch().AddToNationResearch(thisResearch);

    }

    public void SetResearch(Research research)
    {
        thisResearch = research;
    }

}
