using UnityEngine;

[CreateAssetMenu(menuName = "Configs/ResourceConfig")]

public class ResourceConfig : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] private string _resourceId = "default";
    [SerializeField] private string _displayName = "Resource";
    [SerializeField] private Sprite _icon;

    [Header("Production Visuals")]
    public string ResourceId => _resourceId;
    public string DisplayName => _displayName;
    public Sprite Icon => _icon;
}