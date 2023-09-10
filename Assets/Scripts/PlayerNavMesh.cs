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
        //_animator.SetBool("IsWalking", false);

        if (Input.GetMouseButton(0))
        {
            _mousePosition.MousePosition();
            _navMeshAgent.destination = _mousePosition.MousePositionVector;
<<<<<<< HEAD

            if (!HasReachedDestination())
            {
                _animator.SetBool("IsWalking", true);
                //_animation.Play("run");
                Debug.Log("Достиг");
            }

        }
    }

    private bool HasReachedDestination()
    {
        NavMeshPath path = new NavMeshPath();
        bool hasPath = _navMeshAgent.CalculatePath(_mousePosition.MousePositionVector, path);
        if (hasPath)
        {
            if (path.corners.Length > 1)
            {
                return false; // Player is still moving towards the destination
            }
            else
            {
                return true; // Player has reached the destination
            }
        }
        else
        {
            Debug.Log("No path found");
            return false; // No path found
=======
>>>>>>> PlayerMove
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

