using System;
using UnityEngine;
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private int _health;
    [SerializeField] private int _armor;
    [SerializeField] private int _powerAttack;
    [SerializeField] private float _speed;

    private Head _head;
    private Body _body;
    private Rigidbody _rigidbody;
    private GameObject _target;

    public GameObject Target => _target;

    public void Idle()
    {
        
    }

    public void Move(Vector3 direction)
    {
        _rigidbody .AddForce(direction.normalized * Time.deltaTime * _speed * _rigidbody.mass, ForceMode.Force);
        float angleRotation = Mathf.Atan2(direction.x , direction.z) / Mathf.PI * 360;
        Rotate(angleRotation);
    }

    public void Rotate(float angle)
    {
        if (_health <= 0)
        {
            return;
        }
        
        _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation,Quaternion.Euler(0,angle,0) ,Time.deltaTime * _speed);
    }

    public void SimpleAttack()
    {
        Debug.Log("Simple Attack");
    }

    public void PowerAttack()
    {
        Debug.Log("Power Attack");
    }

    public void TakeHit(int damage)
    {
        Debug.Log("Take Damage");
    }

    public void Dead()
    {
        Debug.Log("Is Dead!");
    }

    private void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, Int32.MaxValue);
        _health -= damage;
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
