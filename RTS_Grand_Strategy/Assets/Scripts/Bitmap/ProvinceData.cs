using UnityEngine;

[System.Serializable]
public class ProvinceData
{

    public ProvinceData(Color color, int id, string type, float x, float y)
    {
        ProvinceColor = color;
        ProvinceID = id;
        Type = type;
        MovementPosition = new Vector2(x,y);
    }

    public Color ProvinceColor;
    public int ProvinceID;
    public string Type;
    public Vector2 MovementPosition;

}
