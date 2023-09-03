using UnityEngine;

class Player : Character
{
    private Attack _attack;
    private Animation _animation;

    private void Start()
    {
        _attack = GameObject.Find("Scripts").GetComponent<Attack>();
        _animation = GameObject.Find("Scripts").GetComponent<Animation>();
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
