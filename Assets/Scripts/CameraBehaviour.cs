using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Vector3 _offset;
    void Start()
    {
        _offset = transform.position - _playerTransform.transform.position;
    }

    void Update()
    {
        transform.position = _offset + _playerTransform.transform.position;
    }
}
