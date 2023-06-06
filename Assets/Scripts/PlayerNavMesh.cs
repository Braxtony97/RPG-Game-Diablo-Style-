using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private GetMousePosition _mousePosition;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _mousePosition = GameObject.Find("Scripts").GetComponent<GetMousePosition>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition.MousePosition();
            _navMeshAgent.destination = _mousePosition.MousePositionVector;

        }
    }
}
