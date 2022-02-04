using UnityEngine;

[CreateAssetMenu(menuName = "Building Type")]
public class BuildingType : ScriptableObject
{

    public string Name;

    public Sprite Icon;

    public int BuildingTime;

    public int BuildingCost;

    public void OnBuilt(int nationId)
    {
    }

}
