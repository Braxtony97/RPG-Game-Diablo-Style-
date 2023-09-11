using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GetMousePosition _mousePosition;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _navMeshAgent.stoppingDistance = 0.5f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition.MousePosition();
            _navMeshAgent.destination = _mousePosition.MousePositionVector;
        }
        IsWalking();
    }

    private void IsWalking ()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_navMeshAgent.pathPending)
            _animator.SetBool("IsWalking", false);
        else
            _animator.SetBool("IsWalking", true);
    }
}

