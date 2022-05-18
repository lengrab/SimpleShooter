using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimator : MonoBehaviour, ICharacterAnimator 
{
    private Animator _animator;

    private static readonly int IsRunHash = Animator.StringToHash("IsRun");
    private static readonly int BlendHash = Animator.StringToHash("Blend");
    private static readonly int SimpleAttackHash = Animator.StringToHash("SimpleAttack");
    private static readonly int PowerAttackHash = Animator.StringToHash("PowerAttack");
    private static readonly int HitDamageHash = Animator.StringToHash("HitDamage");
    private static readonly int DeadHash = Animator.StringToHash("Dead");


    public void Idle()
    {
        _animator.SetBool(IsRunHash,false);
        _animator.SetFloat(BlendHash,0);
    }

    public void Run(float speedAnimation)
    {
        if (_animator.GetBool(IsRunHash) == false)
        {
            _animator.SetBool(IsRunHash,true);
        }
        _animator.SetFloat(BlendHash,speedAnimation);
    }

    public void SimpleAttack()
    {
        _animator.SetTrigger(SimpleAttackHash);
    }

    public void PowerAttack()
    {
        _animator.SetTrigger(PowerAttackHash);
    }

    public void HitDamage()
    {
        _animator.SetTrigger(HitDamageHash);
    }

    public void Dead()
    {
        _animator.SetTrigger(DeadHash);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
