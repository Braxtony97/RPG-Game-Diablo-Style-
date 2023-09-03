using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GetMousePosition _mousePosition;
    [SerializeField] private Animation _animation;
    [SerializeField] private Animator _animator;
    private Transform _transformPlayer;

    private void Awake()
    {
        _transformPlayer = GetComponent<Transform>();
        //_navMeshAgent.stoppingDistance = 1.0f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition.MousePosition();
            _navMeshAgent.destination = _mousePosition.MousePositionVector;
            //_animator.SetBool("IsWalking", true);
            /*if (_navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                //_animation.Play("run");
                Debug.Log("Достиг");
            }*/

        }
    }
}

