using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour, IResourceManager
{
    private Dictionary<string, int> _resources = new();

    public void AddResource(string resourceId, int amount)
    {
        if (!_resources.ContainsKey(resourceId)) _resources[resourceId] = 0;
        _resources[resourceId] += amount;
    }

    public int GetResourceCount(string resourceId)
    {
        return _resources.TryGetValue(resourceId, out var count) ? count : 0;
    }
}