using UnityEngine;

class Player : Character
{
    private Attack _attack;

    private void Start()
    {
        _attack = GameObject.Find("Scripts").GetComponent<Attack>();
    }
    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        _attack.PlayerAttack();
    }
}
