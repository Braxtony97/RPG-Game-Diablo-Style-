using Assets.Scripts.Interface;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Animator _animator;
    private string _attackParameterAnimator = "IsAttack";

    public void Hit(bool Bool)
    {
        if (Bool)
        {
            _animator.SetBool(_attackParameterAnimator, true);
        }
        else
        {
            _animator.SetBool(_attackParameterAnimator, false);
        }
    }
}

