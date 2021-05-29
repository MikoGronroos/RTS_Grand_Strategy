using UnityEngine;

[CreateAssetMenu(menuName = "Unit", fileName = "New Unit")]
public class Unit : ScriptableObject
{

    public UnitCategory[] Categories;

    public UnitType Type;

}
