using UnityEngine;

public class NationDetails : MonoBehaviour
{

    [SerializeField] private string currentlySelectedNationId;

    [Header("Events")]

    [SerializeField] private GameEvent onAcceptedAgreement;

    public void NationDetailToggleListener()
    {

        string id = GameEventHub.OnNationDetailToggle.NationId;

        currentlySelectedNationId = id;
    }

    public void AcceptVerification(int type)
    {

        GameEventHub.AcceptedAgreement.Id = type;
        GameEventHub.AcceptedAgreement.TargetNationId = currentlySelectedNationId;

        onAcceptedAgreement?.Invoke();
    }


}
