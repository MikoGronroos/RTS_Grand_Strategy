using UnityEngine;

[CreateAssetMenu(menuName = "Equipment", fileName = "New Equipment")]
public class Equipment : ScriptableObject
{

    public string Name;

    public Sprite Icon;

    public EquipmentType Type;

}
