using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    private CharacterInteraction _interaction;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
        _interaction = GetComponent<CharacterInteraction>();
    }

    private void Update()
    {       
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent<ResourceProducer>(out var producer))
                {
                    _interaction.MoveToBuilding(producer);
                }
                else
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
    }

}