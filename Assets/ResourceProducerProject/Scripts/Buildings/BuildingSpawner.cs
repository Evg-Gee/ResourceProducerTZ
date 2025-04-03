using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _buildingPrefabs;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Vector3 _offset = Vector3.right * 10f; 

    private BuildingFactory _factory = new BuildingFactory();
    private List <GameObject> _spawnedBuildings = new List<GameObject>();

    private void Start()
    {
        SpawnBuildings();
    }

    private void SpawnBuildings()
    {
        Vector3 currentPosition = _startPosition.position;
        
        for (int i = 0; i < _buildingPrefabs.Length; i++)
        {
            GameObject building = _factory.CreateBuilding(_buildingPrefabs[i], currentPosition, transform);
            _spawnedBuildings.Add(building);
            currentPosition += _offset; // Смещаем позицию для следующего здания
        }
    }
}