using UnityEngine;
using UnityEngine.UI;

public class SelectNationUI : MonoBehaviour
{
    [SerializeField] private Button[] nationButtons;

    [SerializeField] GameEvent onNationButtonPressed;

    public void OnGameStartListener()
    {

        string[] ids = GameEventHub.GameStart.ids;

        for (int i = 0; i < nationButtons.Length; i++)
        {
            int index = i;
            nationButtons[index].onClick.AddListener(() => {
                SelectCountry(ids[index]);
            });
        }
    }

    private void SelectCountry(string id)
    {
        GameEventHub.NationButtonPressed.ID = id;
        onNationButtonPressed?.Invoke();
    }

}
