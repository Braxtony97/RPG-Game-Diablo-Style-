using UnityEngine;

namespace Assets.Scripts.Interface
{
    internal interface IDamageable
    {
        void TakeDamage(int Damage);

        Transform GetTransform();//Все что получает урон - должно так же говорить в какой он позиции
    }
}
