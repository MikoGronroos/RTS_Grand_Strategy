using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectNation : MonoBehaviour
{

    [SerializeField] private string[] ids;

    [SerializeField] private GameEvent onGameStart;

    private void Start()
    {
        GameEventHub.GameStart.ids = ids;
        onGameStart?.Invoke();
    }

    public void OnNationSelected()
    {
        string id = GameEventHub.NationButtonPressed.ID;

        FindObjectOfType<GameInitializer>().ID = id;

        SceneManager.LoadScene(1);

    }

}
