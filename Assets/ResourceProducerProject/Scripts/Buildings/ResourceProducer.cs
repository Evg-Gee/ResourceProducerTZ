using UnityEngine;
using System;
using System.Collections;

public class ResourceProducer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _productionEffect;
    [SerializeField] private BuildingConfig _config;
    [SerializeField] private Transform _collectPoint;
    private int _currentAmount;
    private string _resourceId;

    public event Action<int> OnAmountUpdated;
    
    public string ResourceId => _resourceId;
    public int Amount => _currentAmount;

    private void Start()
    {
        _resourceId = _config.ProducedResourceId.ResourceId;
        StartCoroutine(ProduceResources());
    }

    private IEnumerator ProduceResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(_config.ProductionInterval);
            _currentAmount += _config.ProductionAmount;
            OnAmountUpdated?.Invoke(_currentAmount);
            _productionEffect?.Play();
        }
    }
    
    public Transform GetCollectPoint()
    {
        return _collectPoint;
    }

    public void CollectResources(IResourceManager resourceManager)
    {
        resourceManager.AddResource(_resourceId, _currentAmount);
    }
    
    public void SetСollectedResources()
    {
         _currentAmount = 0;
         OnAmountUpdated?.Invoke(_currentAmount);
    }
}