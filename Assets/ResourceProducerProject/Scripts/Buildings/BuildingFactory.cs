using UnityEngine;

public class BuildingFactory 
{
    public GameObject CreateBuilding(GameObject prefab, Vector3 position, Transform parent)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity, parent);
    }
}
