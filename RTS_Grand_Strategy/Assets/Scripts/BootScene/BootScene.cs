using UnityEngine;

public class BootScene : MonoBehaviour
{

    public static System.Action OnBootSceneStarted;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        OnBootSceneStarted?.Invoke();
    }

}
