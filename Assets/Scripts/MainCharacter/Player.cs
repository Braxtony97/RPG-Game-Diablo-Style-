using Assets.Scripts.MainCharacter;
using UnityEngine;

class Player : Character
{
    [Header("Player stats")]
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 10;

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Update()
    {
        Attack();
    }

    public void Attack()
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
