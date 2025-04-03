using UnityEngine;

[CreateAssetMenu(menuName = "Configs/BuildingConfig")]
public class BuildingConfig : ScriptableObject
{
    [Header("Production")]
    public ResourceConfig  ProducedResourceId;
    public float ProductionInterval = 5f;
    public int ProductionAmount = 1;
}