using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterInteraction : MonoBehaviour
{   
    [SerializeField] private float _offset = 4f; 
    private IResourceManager _resourceManager;
    private ResourceProducer _targetProducer;
    private PopupPresenter _popupPresenter;
    private NavMeshAgent _agent;
    

    public void Initialize(IResourceManager resourceManager, PopupPresenter popupPresenter)
    {
        _resourceManager = resourceManager;
        _popupPresenter = popupPresenter;
        _agent = GetComponent<NavMeshAgent>();
    }
    public void MoveToBuilding(ResourceProducer producer)
    {
        if (producer == null) return;

        _targetProducer = producer;
        Vector3 targetPosition = GetOffsetPosition(producer.GetCollectPoint().position);
        _agent.SetDestination(targetPosition);
        StartCoroutine(CheckArrival(targetPosition));
    }
    public void CancelBuildingInteraction()
    {
        _targetProducer = null;
    }
    private Vector3 GetOffsetPosition(Vector3 buildingPosition)
    {
        Vector3 direction = (transform.position - buildingPosition).normalized;
        Vector3 offsetPosition = buildingPosition + direction * _offset;

        if (NavMesh.SamplePosition(offsetPosition, out NavMeshHit hit, _offset, NavMesh.AllAreas))
        {
            return hit.position;
        }
        
        return buildingPosition;
    }

    private IEnumerator CheckArrival(Vector3 targetPosition)
    {
        while (_agent.pathPending || _agent.remainingDistance > _agent.stoppingDistance)
        {
            yield return null;
        }

        CollectResourcesFromBuilding();
    }

    private void CollectResourcesFromBuilding()
    {
        if (_resourceManager == null || _targetProducer == null)
        {
            return;
        }
        if(_targetProducer.Amount>0)
        {
           _targetProducer.CollectResources(_resourceManager);
           _popupPresenter.ShowPopup(_targetProducer.ResourceId,_targetProducer.Amount, _resourceManager.GetResourceCount(_targetProducer.ResourceId));
           SoundManager.Instance.PlayEffect();
           _targetProducer.SetСollectedResources();
            
           _targetProducer = null;
        }
        else
        {
            return;
        }         
    }
    
}