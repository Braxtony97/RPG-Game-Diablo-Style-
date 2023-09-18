using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    class Enemy : Character, IHealth
    {
        [Header("Enemy stats")]
        [SerializeField] private int _health = 100;

        public void AddHealth()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveHealth(int DamageValue)
        {
            _health -= DamageValue;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}
