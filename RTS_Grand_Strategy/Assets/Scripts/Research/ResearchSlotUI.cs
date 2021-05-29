using UnityEngine;
using UnityEngine.UI;

public class ResearchSlotUI : MonoBehaviour
{

    [SerializeField] private Image currentResearchIcon;

    public void ChangeResearch(Research research)
    {
        currentResearchIcon.sprite = research.Icon;
    }

}
