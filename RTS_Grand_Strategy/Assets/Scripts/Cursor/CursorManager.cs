using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private List<Texture2D> cursorTextures = new List<Texture2D>();

    private static Dictionary<string, Texture2D> cursorDictionary = new Dictionary<string, Texture2D>();

    private void Start()
    {
        for (int i = 0; i < cursorTextures.Count; i++)
        {
            cursorDictionary.Add(cursorTextures[i].name, cursorTextures[i]);
        }
    }

    public static void ChangeCursor(string id)
    {
        if (cursorDictionary.ContainsKey(id))
        {
            Cursor.SetCursor(cursorDictionary[id], Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
