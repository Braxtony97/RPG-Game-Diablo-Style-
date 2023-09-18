using UnityEngine;

namespace Assets.Scripts.Enemy
{
    class DaggerAttack : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy _enemy = other.GetComponent<Enemy>();
                _enemy.RemoveHealth(10);
                Debug.Log("Get Damage");
            }
        }
    }
}
