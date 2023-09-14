using UnityEngine;

class Player : Character
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerAttack _playerAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _playerAttack.Hit(true);
        }
        else
        {
            _playerAttack.Hit(false);
        }
    }
}
