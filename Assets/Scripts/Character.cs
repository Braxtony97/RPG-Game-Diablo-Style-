using UnityEngine;

abstract class Character : MonoBehaviour
{
    public int Health;
    public int Damage;

    public abstract void Attack();

    /*abstract public void Move();

    abstract public void GetDamage();*/
}
