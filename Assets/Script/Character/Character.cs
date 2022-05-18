using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private int _health;
    [SerializeField] private int _armor;
    [SerializeField] private int _powerAttack;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation = 5;
    [SerializeField] private bool _followRotatetionToMove = true;
    [SerializeField] private bool _IsDebug = true;

    private Head _head;
    private Body _body;
    private CharacterAnimator _animator;
    private Rigidbody _rigidbody;

    public void Idle()
    {
        _animator.Idle();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody .AddForce(direction.normalized * Time.deltaTime * _speed * _rigidbody.mass, ForceMode.Force);
        _animator.Run(Mathf.Clamp(_rigidbody.velocity.magnitude,0f,1f));
        
        if (_followRotatetionToMove)
        {
            float angleRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Rotate(angleRotation);
        }
    }

    public void Rotate(float angle)
    {
        if (_health <= 0)
        {
            return;
        }
        
        _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation,Quaternion.Euler(0,angle,0) ,Time.deltaTime * _speedRotation);
    }

    public void SimpleAttack()
    {
        _animator.SimpleAttack();

        if (_IsDebug)
        {
            Debug.Log("Simple Attack");
        }
    }

    public void PowerAttack()
    {
        _animator.PowerAttack();

        if (_IsDebug)
        {
            Debug.Log("Power Attack");
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage - _armor, 0, Int32.MaxValue);
        _health -= damage;
        _animator.HitDamage();

        if (_IsDebug)
        {
            Debug.Log("Take Damage");
        }
    }

    public void Dead()
    {
        _animator.Dead();

        if (_IsDebug)
        {
            Debug.Log("Is Dead!");
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<CharacterAnimator>();
        _body = GetComponentInChildren<Body>();
        _head = GetComponentInChildren<Head>();
    }

    private void OnEnable()
    {
        _head.WeaponVisited += TakeDamage;
        _body.WeaponVisited += TakeDamage;
    }

    private void OnDisable()
    {
        _head.WeaponVisited -= TakeDamage;
        _body.WeaponVisited -= TakeDamage;
    }
}
