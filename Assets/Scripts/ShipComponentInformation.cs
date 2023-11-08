using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponentInformation", menuName = "ScriptableObjects/ShipComponent", order = 0)]
public class ShipComponentInformation : ScriptableObject
{
    public Sprite _sprite;
    public string _componentName;
    public ModuleType _moduleType;

    public enum ModuleType { Gym, MedicalBay, Cabins, Module }
}
